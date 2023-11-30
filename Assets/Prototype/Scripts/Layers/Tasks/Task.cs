using System;

namespace Prototype.Scripts.Layers.Tasks
{
    public class Task
    {
        public readonly int StartTime;
        public readonly int EndTime;
        public bool IsActive;
        public readonly Layer ParentLayer;
        public TaskWindow TaskWindow;
        public event Action TurnedOn;
        public event Action TurnedOff;

        public Task(int startTime, int endTime, Layer parentlayer)
        {
            StartTime = startTime;
            EndTime = endTime;
            ParentLayer = parentlayer;
            IsActive = false;
        }

        public void TurnOn()
        {
            IsActive = true;
            TurnedOn?.Invoke();
        }

        public void TurnOff()
        {
            IsActive = false;
            TurnedOff?.Invoke();
        }
    }
}