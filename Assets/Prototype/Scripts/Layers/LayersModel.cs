using System;
using System.Collections.Generic;

namespace Prototype.Scripts.Layers
{
    public class LayersModel
    {
        public Pool<LayerWindow> PoolLayerWindows;
        
        public List<Layer> Layers;
        public List<Layer> IncludedLayers;
        
        public event Action AddedLayer;
        public event Action<Layer> RemovedLayer;

        public LayersModel()
        {
            Layers = new List<Layer>();
            IncludedLayers = new List<Layer>();
        }

        public void Addlayer()
        {
            AddedLayer?.Invoke();
        }

        public void RemoveLayer(Layer layer)
        {
            RemovedLayer?.Invoke(layer);
        }
    }
}