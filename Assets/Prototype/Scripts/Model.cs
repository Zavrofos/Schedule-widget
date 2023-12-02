using System;
using Prototype.Scripts.Layers;
using Prototype.Scripts.Layers.Tasks;

namespace Prototype.Scripts
{
    public class Model
    {
        public LayersModel LayersModel;
        public TasksStatusModel TasksStatusModel;
        public VirtualizationModel VirtualizationModel;
        
        public event Action Initialized;
        
        public Model()
        {
            LayersModel = new LayersModel();
            TasksStatusModel = new TasksStatusModel();
            VirtualizationModel = new VirtualizationModel();
        }

        public void Initialize()
        {
            Initialized?.Invoke();
            VirtualizationModel.Initialize();
        }
    }
}