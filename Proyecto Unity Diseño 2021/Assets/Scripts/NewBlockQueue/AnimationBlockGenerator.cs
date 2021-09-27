using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;
using System;

public class AnimationBlockGenerator : MonoBehaviour
{
    public static void RepeatAction(int repeatCount, Action action)
    {
        for (int i = 0; i < repeatCount; i++)
            action();
    }


    /// <summary> Este metodo esta encargado de generar bloques a partir de triggers </summary>
    /// <param name="triggerScriptableObjects"> Triggers a interpretar </param>
    public void AnimarAvatar(List<List<ActionScriptableObject>> triggerScriptableObjects)
    {

        // en caso de encontrar repetidos, guardar la cantidad maxima de repetidos
        // generar tantos bloques como repetidos haya
        var numberOfBlocks = GetGreaterLayer(triggerScriptableObjects);

        List<Block> blockList = new List<Block>(); // Inicializo la lista de lista de bloques
        RepeatAction(numberOfBlocks, () => { blockList.Add(new Block()); }); // Generar tantos bloques como el maximo
    }

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
