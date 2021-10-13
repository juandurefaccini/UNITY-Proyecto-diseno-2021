using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class AnimatorControllerCreator : MonoBehaviour
{
    [Serializable]
    public struct StateDefinition
    {
        public string stateName;
        public Motion stateAnimation;
        public string parameterName;
    }
    [Serializable]
    public struct LayerDefinition
    {
        public string layerName;
        public StateDefinition[] stateDefinitions;
        public AvatarMask mask;

    }

    public LayerDefinition[] layers;
    public string controllerName = "default";
    void Start()
    {
        CreateController();
    }

    void CreateController()
    {
        var controller =
            AnimatorController.CreateAnimatorControllerAtPath(
                ("Assets/Animator/" + SceneManager.GetActiveScene().name + "/" + controllerName + ".controller"));


        var defaultState = controller.layers[0].stateMachine.AddState(layers[0].stateDefinitions[0].stateName); // Tomo el primer layer del arreglo deifnido en el inspector y creo el estado base
        defaultState.motion = layers[0].stateDefinitions[0].stateAnimation; // Asignar el MOTION

        controller.layers[0].stateMachine.defaultState = defaultState; // Asigno el estado por defecto

        // Demas capas
        for (int i = 1; i < layers.Length; i++)
        {
            var currentLayerDef = layers[i];
            controller.AddLayer(currentLayerDef.layerName); //la layer queda con numero i

            // para que Unity nos deje modificar las propiedades de controller.layers
            AnimatorControllerLayer[] l = controller.layers;

            l[i].avatarMask = currentLayerDef.mask;
            l[i].defaultWeight = 1;
            controller.layers = l;

            var currentStateMachine = controller.layers[i].stateMachine;

            //estados
            var layerEmptyState = currentStateMachine.AddState("empty"); // Creo el estado vacio

            currentStateMachine.defaultState = layerEmptyState; // Asigno el estado vacio por defecto
                                                                //layerEmptyState.AddStateMachineBehaviour<ReadyBehaviour>();
            var clearTransition = currentStateMachine.AddAnyStateTransition(layerEmptyState);

            string clearLayerAnimationParameter = "clear" + layers[i].layerName; // Genero el nombre del trigger clear

            controller.AddParameter(clearLayerAnimationParameter, AnimatorControllerParameterType.Trigger); // Asignar el trigger al controller

            clearTransition.AddCondition(AnimatorConditionMode.If, 0, clearLayerAnimationParameter);

            foreach (var stateDefinition in currentLayerDef.stateDefinitions)
            {
                // El trigger para ir al nuevo estado
                controller.AddParameter(stateDefinition.parameterName, AnimatorControllerParameterType.Trigger);

                // Agregar el nuevo estado con su nombre y  animacion
                var state = currentStateMachine.AddState(stateDefinition.stateName);

                // Agrego la motion
                state.motion = stateDefinition.stateAnimation;

                // Agrego : Any State --> Estado actual
                var transition = currentStateMachine.AddAnyStateTransition(state);

                transition.AddCondition(AnimatorConditionMode.If, 0, stateDefinition.parameterName);

                transition.hasExitTime = true;

                transition.exitTime = 1;

                state.AddStateMachineBehaviour<ExitBehaviour>();
            }
        }
    }
}
