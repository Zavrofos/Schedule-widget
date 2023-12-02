using System;
using System.Collections.Generic;
using Prototype.Scripts.Layers.Tasks;

namespace Prototype.Scripts.Layers
{
    public class Layer
    {
        public readonly float InitialPosition;
        public LayerWindow LayerWindow;
        public bool IsActive;
        public List<Task> Tasks;
        
        public event Action TurnedOn;
        public event Action TurnedOff;
        public event Action<int, int> AddedTask;
        public event Action<Task> UnsubscribedTaskPresenters;

        public Layer(float initialPosition)
        {
            InitialPosition = initialPosition;
            IsActive = false;
            Tasks = new List<Task>();
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

        public void AddTask(int startTime, int endTime)
        {
            AddedTask?.Invoke(startTime, endTime);
        }

        public void UnsubscribeTaskPresenters(Task task)
        {
            UnsubscribedTaskPresenters?.Invoke(task);
        }
    }
}