using System;
using System.Collections.Generic;

namespace Prototype.Scripts.Layers
{
    public class LayersModel
    {
        public readonly List<Layer> Layers;
        public event Action AddedLayer;

        public LayersModel()
        {
            Layers = new List<Layer>();
        }

        public void Addlayer()
        {
            AddedLayer?.Invoke();
        }
    }
}