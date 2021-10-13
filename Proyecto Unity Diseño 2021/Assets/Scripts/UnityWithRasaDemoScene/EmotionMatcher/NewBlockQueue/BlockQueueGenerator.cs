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
        Block block = new Block();
        foreach (TuplaScriptableObject tupla in triggerScriptableObjects)
        {
            Debug.Log("Trigger dentro del GetBlockQueue: " + tupla.Trigger);
            block.AddLayerInfo(new LayerInfo(tupla.Trigger));
        }
        blocks.Add(block);   //El constructor vacio crea la lista de layer info sin necesidad de pasarsela
        blocks.Add(GetCleanBlock()); // Agrego un bloque con un trigger por defecto
        return new BlockQueue(blocks);
    }
    private static Block GetCleanBlock()
    {
        Block cleanBlock = new Block(new List<LayerInfo> {
            new LayerInfo("clearBothArmsLayer"),
            new LayerInfo("clearFaceLayer"),
            new LayerInfo("clearLeftArmLayer"),
            new LayerInfo("clearLegsLayer"),
            new LayerInfo("clearRightArmLayer"),
            new LayerInfo("clearTorsoLayer")});
        return cleanBlock;
    }
}
