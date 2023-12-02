using System;

namespace Prototype.Scripts.Layers.Tasks
{
    public class Task
    {
        public readonly int StartTime;
        public readonly int EndTime;
        public bool IsActive;
        public StateTask CurrentState;
        
        public event Action<Layer> TurnedOn;
        public event Action<Layer> TurnedOff;

        public Task(int startTime, int endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            IsActive = false;
            CurrentState = StateTask.Pending;
        }

        public void TurnOn(Layer parentLayer)
        {
            TurnedOn?.Invoke(parentLayer);
        }

        public void TurnOff(Layer parentLayer)
        {
            TurnedOff?.Invoke(parentLayer);
        }
    }
}