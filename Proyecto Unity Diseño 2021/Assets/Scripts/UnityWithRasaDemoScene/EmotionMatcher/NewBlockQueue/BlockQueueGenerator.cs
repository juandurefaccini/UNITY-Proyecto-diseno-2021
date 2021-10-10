using System.Collections.Generic;
using AnimatorComposerStructures;
using UnityWithRasaDemoScene;
using UnityEngine;

public class BlockQueueGenerator
{
    private const string DEFAULT_TRIGGER = " ";
    public static BlockQueue GetBlockQueue(List<TuplaScriptableObject> triggerScriptableObjects)
    {
        List<Block> blocks = new List<Block>();
        blocks.Add(new Block());   //El constructor vacio crea la lista de layer info sin necesidad de pasarsela
        foreach (TuplaScriptableObject tupla in triggerScriptableObjects)
        {
            Debug.Log("Trigger dentro del GetBlockQueue: " + tupla.Trigger);
            blocks[0].AddLayerInfo(new LayerInfo(tupla.Trigger));
        }
        blocks.Add(new Block(GetCleanBlock())); // Agrego un bloque con un trigger por defecto
        return new BlockQueue(blocks);
    }
    private static List<LayerInfo> GetCleanBlock()
    {
        return new List<LayerInfo> {
            new LayerInfo("clearBothArmsLayer"),
            new LayerInfo("clearFaceLayer"),
            new LayerInfo("clearLeftArmLayer"),
            new LayerInfo("clearLegsLayer"),
            new LayerInfo("clearRightArmLayer"),
            new LayerInfo("clearTorsoLayer")};
    }
}

// using System.Collections.Generic;
// using System.Diagnostics;
// using AnimatorComposerStructures;
// using UnityWithRasaDemoScene;
// public class BlockQueueGenerator
// {
//     private const string DEFAULT_TRIGGER = " ";
//     public static BlockQueue GetBlockQueue(List<Tupla> triggerScriptableObjects, string triggerfacial)
//     {
//         List<Block> blocks = new List<Block>();
//         blocks.Add(new Block());   //El constructor vacio crea la lista de layer info sin necesidad de pasarsela
//         foreach (TuplaScriptableObject tupla in triggerScriptableObjects)
//         {
//             blocks[0].AddLayerInfo(new LayerInfo(tupla.Trigger));
//         }
//         blocks[0].AddLayerInfo(new LayerInfo(triggerfacial));
//         blocks.Add(new Block(GetCleanBlock())); // Agrego un bloque con un trigger por defecto
//         return new BlockQueue(blocks);
//     }
//     private static List<LayerInfo> GetCleanBlock()
//     {
//         return new List<LayerInfo> {
//             new LayerInfo("clearBothArmsLayer"),
//             new LayerInfo("clearFaceLayer"),
//             new LayerInfo("clearLeftArmLayer"),
//             new LayerInfo("clearLegsLayer"),
//             new LayerInfo("clearRightArmLayer"),
//             new LayerInfo("clearTorsoLayer")};
//     }
// }