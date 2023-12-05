using System;
using Prototype.Scripts.Layers;
using Prototype.Scripts.Random;
using Prototype.Scripts.TimeLine;
using Prototype.Scripts.TimeScaleDir;
using Prototype.Scripts.WorkZone;

namespace Prototype.Scripts
{
    public class Model
    {
        public LayersModel LayersModel;
        public TasksStatusModel TasksStatusModel;
        public VirtualizationModel VirtualizationModel;
        public WorkZoneModel WorkZoneModel;
        public RandomizeModel RandomizeModel;
        public TimeScaleModel TimeScaleModel;
        public TimeLineModel TimeLineModel;

        public event Action Initialized;
        
        public Model()
        {
            LayersModel = new LayersModel();
            TasksStatusModel = new TasksStatusModel();
            VirtualizationModel = new VirtualizationModel();
            WorkZoneModel = new WorkZoneModel();
            RandomizeModel = new RandomizeModel();
            TimeScaleModel = new TimeScaleModel();
            TimeLineModel = new TimeLineModel();
        }

        public void Initialize()
        {
            Initialized?.Invoke();
        }
    }
}