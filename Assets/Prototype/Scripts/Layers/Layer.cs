using System;
using System.Collections.Generic;
using Prototype.Scripts.Tasks;

namespace Prototype.Scripts.Layers
{
    public class Layer
    {
        public readonly float InitialPosition;
        public bool IsActive;
        public List<Task> Tasks;
        public List<(float, float)> TasksPositions;
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
            Tasks = new List<Task>();
            IncludedTasks = new Dictionary<Task, TaskWindow>();
            TasksPositions = new List<(float, float)>();
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
        
        public int GetLeftBoardTaskPosition(float upBoard)
        {
            int left = 0;
            int right = TasksPositions.Count;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (TasksPositions[mid].Item2 < upBoard)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        public int GetRightBoardTaskPosition(float downBoard)
        {
            int left = 0;
            int right = TasksPositions.Count;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (TasksPositions[mid].Item1 <= downBoard)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left - 1;
        }
    }
}