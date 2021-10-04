using System.Collections.Generic;
using AnimatorComposerStructures;
using UnityWithRasaDemoScene;
public class BlockQueueGenerator
{
    private const string DEFAULT_TRIGGER = " ";
    public static BlockQueue GetBlockQueue(List<Tupla> triggerScriptableObjects)
    {
        List<Block> blocks = new List<Block>();
        Tupla tupla1 = triggerScriptableObjects[0];
        if (triggerScriptableObjects.Count > 1)
        {
            // Son dos triggers
            // Como son dos triggers, debo verificar si son o no de la misma Layer
            Tupla tupla2 = triggerScriptableObjects[1];
            if (tupla1.Layer == tupla2.Layer)
            {
                // Son de la misma Layer
                // Generar dos bloques, uno por cada capa
                blocks = new List<Block>() { new Block(tupla1.Trigger), new Block(tupla2.Trigger) }; // Genero una lista de bloques de dos bloques con un solo trigger
            }
            else
            {
                blocks = new List<Block>() { new Block(new List<LayerInfo> { new LayerInfo(tupla1.Trigger), new LayerInfo(tupla2.Trigger) }) }; // Genero un bloque con dos triggers
            }

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
