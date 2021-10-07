using System.Collections.Generic;
using System.Diagnostics;
using AnimatorComposerStructures;
using UnityWithRasaDemoScene;
public class BlockQueueGenerator
{
    private const string DEFAULT_TRIGGER = " ";
    public static BlockQueue GetBlockQueue(List<Tupla> triggerScriptableObjects, string triggerFacial)
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
                // Generar un bloque, descartar el 2do trigger
                blocks = new List<Block>() { new Block(new List<LayerInfo> { new LayerInfo(tupla1.Trigger)})}; // Genero un bloque con un solo trigger
            }   
            else
            {
                blocks = new List<Block>() { new Block(new List<LayerInfo> { new LayerInfo(tupla1.Trigger), new LayerInfo(tupla2.Trigger) }) }; // Genero un bloque con dos triggers
            }

        }
        else
        {
            // Es un trigger
            blocks = new List<Block>() { new Block(new List<LayerInfo> { new LayerInfo(tupla1.Trigger) }) }; // Genero un bloque con un solo trigger
        }
        blocks[0].AddLayerInfo(new LayerInfo(triggerFacial));
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

//-------------------------------------------------------------------------//
//SI SON DOS O MAS TRIGGERS DE DIFERENTES lAYER SI O SI

/*
using System.Collections.Generic;
using System.Diagnostics;
using AnimatorComposerStructures;
using UnityWithRasaDemoScene;
public class BlockQueueGenerator
{
    private const string DEFAULT_TRIGGER = " ";
    public static BlockQueue GetBlockQueue(List<Tupla> triggerScriptableObjects, string triggerFacial)
    {
        List<Block> blocks = new List<Block>();
        blocks.Add(new Block());   //El constructor vacio crea la lista de layer info sin necesidad de pasarsela
        foreach (Tupla tupla in triggerScriptableObjects)
        {
            blocks[0].AddLayerInfo(new LayerInfo(triggerFacial));
        }
        blocks[0].AddLayerInfo(new LayerInfo(triggerFacial));
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
*/