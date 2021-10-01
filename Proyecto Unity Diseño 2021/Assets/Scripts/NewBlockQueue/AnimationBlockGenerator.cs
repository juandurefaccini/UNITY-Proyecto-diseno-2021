using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;
using System;
using System.Linq;

public class AnimationBlockGenerator : MonoBehaviour
{
    private const string DEFAULT_TRIGGER = " ";
    public List<Block> blocks;
    public static void RepeatAction(int repeatCount, Action action)
    {
        for (int i = 0; i < repeatCount; i++)
            action();
    }

    /*

        /// <summary> Este metodo esta encargado de generar bloques a partir de triggers </summary>
        /// <param name="triggerScriptableObjects"> Triggers a interpretar </param>
        public void AnimarAvatar(List<List<ActionScriptableObject>> triggerScriptableObjects)
        {

            // en caso de encontrar repetidos, guardar la cantidad maxima de repetidos
            // generar tantos bloques como repetidos haya
            var numberOfBlocks = GetGreaterLayer(triggerScriptableObjects); // Obtener la cantidad de bloques

            List<Block> blockList = new List<Block>(); // Inicializo la lista de lista de bloques
            RepeatAction(numberOfBlocks, () => { blockList.Add(new Block()); }); // Generar tantos bloques como el maximo


            foreach (var block in blockList.Select((value, index) => new { value, index })) // Para cada bloque a generar
            {
                // Por cada bloque de la lista de bloques a exportar
                var currentBlock = block.value;
                foreach (var trigger in triggerScriptableObjects.Select((value, index) => new { value, index }))
                {
                    // Por cada trigger de la lista de triggers que fueron seleccionadas
                    var actionName = triggerScriptableObjects[trigger.index][block.index].actionName;

                    if (actionName == null) actionName = DEFAULT_TRIGGER; // Supongamos que son 5 bloques. En caso que no hayan 5 triggers para la misma capa se llena con vacios
                    currentBlock.AddLayerInfo(new LayerInfo(actionName));
                }
                blockList.Add(currentBlock);
            }
            blocks = blockList;
        }

        */


    /// <summary> Obtiene el mayor numero de triggers </summary>
    private int GetGreaterLayer(List<List<ActionScriptableObject>> triggerScriptableObjects)
    {
        int max = 0;
        foreach (List<ActionScriptableObject> list in triggerScriptableObjects)
        {
            // Si la cantidad de triggers de la lista es mayor a la maxima, entonces reemplaza
            if (list.Count > max) max = list.Count;
        }
        return max;
    }
}
