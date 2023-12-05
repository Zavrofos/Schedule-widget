using System;
using System.Collections.Generic;
using Prototype.Scripts.Tasks;
using Prototype.Scripts.Tree;

namespace Prototype.Scripts.Layers
{
    public class Layer
    {
        public readonly float InitialPosition;
        public bool IsActive;

        public Task PreviousTask;
        public BinaryTree<float, Task> Tasks;
        public Dictionary<Task, TaskWindow> IncludedTasks;

        public event Action TurnedOn;
        public event Action TurnedOff;
        public event Action<int, int> AddedTask;
        public event Action<Task> RemovedTask;
        public event Action SettedStateTasks;

        public Layer(float initialPosition)
        {
            InitialPosition = initialPosition;
            IsActive = false;
            IncludedTasks = new Dictionary<Task, TaskWindow>();
            Tasks = new BinaryTree<float, Task>();
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

        public void SetStateTasks()
        {
            SettedStateTasks?.Invoke();
        }
    }
}