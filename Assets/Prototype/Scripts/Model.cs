using System;
using Prototype.Scripts.Layers;
using Prototype.Scripts.Layers.Tasks;

namespace Prototype.Scripts
{
    public class Model
    {
        public Pool<LayerWindow> PoolLayerWindows;
        public Pool<TaskWindow> PoolTaskWindows;
        public readonly LayersModel LayersModel;
        public event Action Initialized;
        public event Action ContentScrollPositionChanged;

        public Model()
        {
            LayersModel = new LayersModel();
        }

        public void Initialize()
        {
            Initialized?.Invoke();
            ContentScrollPositionChanged?.Invoke();
        }

        public void ChangeContentScrollPosition()
        {
            ContentScrollPositionChanged?.Invoke();
        }
    }
}