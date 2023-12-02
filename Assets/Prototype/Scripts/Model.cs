using System;
using Prototype.Scripts.Layers;
using Prototype.Scripts.Layers.Tasks;

namespace Prototype.Scripts
{
    public class Model
    {
        public Pool<LayerWindow> PoolLayerWindows;
        public LayersModel LayersModel;
        
        public event Action Initialized;
        public event Action ContentScrollPositionChangedVertical;
        public event Action ContentScrollPositionChangedHorizontal;

        public int PendingCount;
        public int JeopardyCount;
        public int CompletedCount;

        public Model()
        {
            LayersModel = new LayersModel();
        }

        public void Initialize()
        {
            Initialized?.Invoke();
            ContentScrollPositionChangedVertical?.Invoke();
            ContentScrollPositionChangedHorizontal?.Invoke();
        }

        public void ChangeContentScrollPositionVertical()
        {
            ContentScrollPositionChangedVertical?.Invoke();
        }
        
        public void ChangeContentScrollPositionHorizontal()
        {
            ContentScrollPositionChangedHorizontal?.Invoke();
        }
    }
}