using System;
using System.Collections.Generic;
using Prototype.Scripts.avl_tree_c_sharp_master.Bitlush.AvlTree;

namespace Prototype.Scripts.Layers
{
    public class LayersModel
    {
        public Pool<LayerWindow> PoolLayerWindows;

        public Layer PreviousLayer;

        public List<Layer> Layers;
        public List<float> LayersPositions;
        public Dictionary<Layer, LayerWindow> IncludedLayers;
        
        public event Action AddedLayer;
        public event Action<Layer> RemovedLayer;
        
        public LayersModel()
        {
            Layers = new List<Layer>();
            LayersPositions = new List<float>();
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


        public int GetUpBoardLayerPosition(float upBoard)
        {
            int left = 0;
            int right = LayersPositions.Count;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (LayersPositions[mid] < upBoard)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        public int GetDownBoardLayerPosition(float downBoard)
        {
            int left = 0;
            int right = LayersPositions.Count;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (LayersPositions[mid] <= downBoard)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left - 1;
        }
    }
}