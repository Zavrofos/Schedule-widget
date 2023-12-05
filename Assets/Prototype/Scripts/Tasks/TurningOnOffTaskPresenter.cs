using Prototype.Scripts.Layers;
using UnityEngine;

namespace Prototype.Scripts.Tasks
{
    public class TurningOnOffTaskPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly Task _task;
        private readonly View _view;

        public TurningOnOffTaskPresenter(Model model, Task task, View view)
        {
            _model = model;
            _task = task;
            _view = view;
        }

        public void Subscribe()
        {
            _task.TurnedOn += OnTurnOn;
            _task.TurnedOff += OnTurnOff;
        }

        public void Unsubscribe()
        {
            _task.TurnedOn -= OnTurnOn;
            _task.TurnedOff -= OnTurnOff;
        }
        
        private void OnTurnOn(Layer parentLayer)
        {
            TaskWindow taskWindow = _model.LayersModel.IncludedLayers[parentLayer].PoolTaskWindows.GetFreeElement();
            
            if (_task.CurrentState == StateTask.Pending)
            {
                taskWindow.Image.color = _view.PendingColorTask;
            }
            else if (_task.CurrentState == StateTask.Completed)
            {
                taskWindow.Image.color = _view.CompletedColorTask;
            }
            else if (_task.CurrentState == StateTask.Jeopardy)
            {
                taskWindow.Image.color = _view.JeopardyColorTask;
            }
            
            int sizeX = _task.EndTime - _task.StartTime;
            float positionX = _task.StartTime + (sizeX / 2);

            taskWindow.TaskRectTransform.sizeDelta = new Vector2(sizeX, taskWindow.TaskRectTransform.sizeDelta.y);
            taskWindow.TaskRectTransform.anchoredPosition = new Vector2(positionX, taskWindow.TaskRectTransform.anchoredPosition.y);

            parentLayer.IncludedTasks.Add(_task, taskWindow);

            _task.IsActive = true;
        }
        
        private void OnTurnOff(Layer parentLayer)
        {
            parentLayer.IncludedTasks[_task].TaskRectTransform.sizeDelta = parentLayer.IncludedTasks[_task].InitialSize;
            parentLayer.IncludedTasks[_task].TaskRectTransform.anchoredPosition = Vector2.zero;
            parentLayer.IncludedTasks[_task].gameObject.SetActive(false);
            _task.IsActive = false;
            parentLayer.IncludedTasks.Remove(_task);
        }
    }
}