using System;
using System.Collections.Generic;
using Prototype.Scripts.Layers.Tasks;

namespace Prototype.Scripts.Layers
{
    public class Layer
    {
        public readonly float InitialPosition;
        public bool IsActive;
        public List<Task> Tasks;
        public Dictionary<Task, TaskWindow> IncludedTasks;

        public event Action TurnedOn;
        public event Action TurnedOff;
        public event Action<int, int> AddedTask;
        public event Action<Task> RemovedTask;

        public Layer(float initialPosition)
        {
            InitialPosition = initialPosition;
            IsActive = false;
            Tasks = new List<Task>();
            IncludedTasks = new Dictionary<Task, TaskWindow>();
        }

        public void TurnOn()
        {
            TurnedOn?.Invoke();
        }

        public void TurnOff()
        {
            TurnedOff?.Invoke();
        }

        public void AddTask(int startTime, int endTime)
        {
            AddedTask?.Invoke(startTime, endTime);
        }

        public void RemoveTask(Task task)
        {
            RemovedTask?.Invoke(task);
        }
    }
}