using UnityEngine;

namespace Prototype.Scripts.Layers.Tasks
{
    public class TurningOnTaskPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly Task _task;
        private readonly View _view;

        public TurningOnTaskPresenter(Model model, Task task, View view)
        {
            _model = model;
            _task = task;
            _view = view;
        }

        public void Subscribe()
        {
            _task.TurnedOn += OnTurnOn;
        }

        public void Unsubscribe()
        {
            _task.TurnedOn += OnTurnOn;
        }

        private void OnTurnOn()
        {
            TaskWindow taskWindow = _task.ParentLayer.LayerWindow.PoolTaskWindows.GetFreeElement();
            
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

            _task.TaskWindow = taskWindow;
        }
    }
}