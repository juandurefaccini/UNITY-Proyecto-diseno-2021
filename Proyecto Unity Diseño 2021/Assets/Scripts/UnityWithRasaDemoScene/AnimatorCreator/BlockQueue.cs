using System.Collections.Generic;

namespace AnimatorComposerStructures
{
    public class BlockQueue
    {
        // Cola de prioridad de bloques que nos permite secuencializar las animaciones
        Queue<Block> blocks;

        public BlockQueue() => blocks = new Queue<Block>();
        public BlockQueue(List<Block> blocks) => this.blocks = new Queue<Block>(blocks);

        // Encolar
        public void Enqueue(Block block) => blocks.Enqueue(block);

        public Queue<Block> GetBlocks() => blocks;
        // Desencolar
        public Block Dequeue() => blocks.Dequeue();

        public bool IsEmpty() => blocks.Count == 0; // Peek agarra la primera, si es null esta vacia

        public void Clear() => blocks.Clear();

        public override string ToString()
        {
            string result = "";
            foreach (Block block in blocks)
            {
                result += block.ToString() + "\n";
            }
            return result;
        }
    }
}

public class Block
{
    // Clase encargada de almacenar los distintos cambios que se le haran a los layers
    private List<LayerInfo> stateTransitions;


    // DEPRECATED
    public Block(List<LayerInfo> stateTransitions)
    {
        this.stateTransitions = stateTransitions;
    }
    public Block(string stateTransition)
    {
        this.stateTransitions = new List<LayerInfo>() { new LayerInfo(stateTransition) };
    }

    public Block()
    {
        this.stateTransitions = new List<LayerInfo>();
    }

    // Diccionario para almacenar el layer a editar y el valor del mismo

    public List<LayerInfo> GetLayerInfos()
    {
        return stateTransitions;
    }

    public void AddLayerInfo(LayerInfo layerInfo)
    {
        stateTransitions.Add(layerInfo);
    }
}

public class LayerInfo
{
    public string DestinyState { get; }

    public LayerInfo(string destinyState)
    {
        this.DestinyState = destinyState;
    }

}