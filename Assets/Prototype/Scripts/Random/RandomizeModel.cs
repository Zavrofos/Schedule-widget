using System;
using Prototype.Scripts.Layers;

namespace Prototype.Scripts.Random
{
    public class RandomizeModel
    {
        public event Action<Layer, int> RandomlyFilledTheLayer;
        public event Action SettedRandomLayers;
        
        public void RandomFillLayer(Layer layer, int countTask)
        {
            RandomlyFilledTheLayer?.Invoke(layer, countTask);
        }

        public void SetRandomLayers()
        {
            SettedRandomLayers?.Invoke();
        }
    }
}