using System;
using System.Collections.Generic;
using Prototype.Scripts.avl_tree_c_sharp_master.Bitlush.AvlTree;

namespace Prototype.Scripts.Layers
{
    public class LayersModel
    {
        public Pool<LayerWindow> PoolLayerWindows;

        public Layer PreviousLayer;
        public AvlNode<float, Layer> MinNode;
        
        public AvlTree<float, Layer> Layers;
        public Dictionary<Layer, LayerWindow> IncludedLayers;
        
        public event Action AddedLayer;
        public event Action<Layer> RemovedLayer;

        public LayersModel()
        {
            Layers = new AvlTree<float, Layer>();
            IncludedLayers = new Dictionary<Layer, LayerWindow>();
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