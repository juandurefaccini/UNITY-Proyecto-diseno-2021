using System.Collections.Generic;

namespace AnimatorComposerStructures
{
    public class BlockQueue
    {
        // Cola de prioridad de bloques que nos permite secuencializar las animaciones
        Queue<Block> blocks;

        public BlockQueue() => blocks = new Queue<Block>();

        // Encolar
        public void Enqueue(Block block) => blocks.Enqueue(block);

        // Desencolar
        public Block Dequeue() => blocks.Dequeue();

        public bool IsEmpty() => blocks.Count == 0; // Peek agarra la primera, si es null esta vacia

        public void Clear() => blocks.Clear();
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
}