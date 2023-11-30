using UnityEngine;

namespace Prototype.Scripts.Layers.Tasks
{
    public class TurningOffTaskPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly Task _task;
        private readonly View _view;

        public TurningOffTaskPresenter(Model model, Task task, View view)
        {
            _model = model;
            _task = task;
            _view = view;
        }

        public void Subscribe()
        {
            _task.TurnedOff += OnTurnOff;
        }

        public void Unsubscribe()
        {
            _task.TurnedOff += OnTurnOff;
        }

        private void OnTurnOff()
        {
            _task.TaskWindow.TaskRectTransform.sizeDelta = new Vector2(100, 80);
            _task.TaskWindow.TaskRectTransform.anchoredPosition = Vector2.zero;
            _task.TaskWindow.gameObject.SetActive(false);
            _task.TaskWindow = null;
        }
    }
}