using System;
using System.Collections.Generic;

namespace Prototype.Scripts.Layers
{
    public class LayersModel
    {
        public List<Layer> Layers;
        public List<Layer> IncludedLayers;
        public event Action AddedLayer;
        public event Action<Layer> UnsubscribedLayerPresenters;

        public LayersModel()
        {
            Layers = new List<Layer>();
            IncludedLayers = new List<Layer>();
        }

        public void Addlayer()
        {
            AddedLayer?.Invoke();
        }

        public void UnsubscribeLayerPresenters(Layer layer)
        {
            UnsubscribedLayerPresenters?.Invoke(layer);
        }
    }
}