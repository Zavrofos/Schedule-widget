using System;
using System.Collections.Generic;
using Prototype.Scripts.Layers.Tasks;

namespace Prototype.Scripts.Layers
{
    public class Layer
    {
        public readonly int InitialPosition;
        public bool IsActive;
        public LayerWindow LayerWindow;
        public event Action<Layer> TurnedOn;
        public event Action<Layer> TurnedOff;

        public List<Task> Tasks;
        public event Action<int, int> AddedTask;

        public Layer(int initialPosition)
        {
            InitialPosition = initialPosition;
            IsActive = false;
            Tasks = new List<Task>();
        }

        public void TurnOn()
        {
            IsActive = true;
            TurnedOn?.Invoke(this);
        }

        public void TurnOff()
        {
            IsActive = false;
            TurnedOff?.Invoke(this);
        }

        public void AddTask(int startTime, int endTime)
        {
            AddedTask?.Invoke(startTime, endTime);
        }
    }
}