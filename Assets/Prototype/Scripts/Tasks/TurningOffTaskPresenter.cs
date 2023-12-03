using Prototype.Scripts.Layers;
using UnityEngine;

namespace Prototype.Scripts.Tasks
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

        private void OnTurnOff(Layer parentLayer)
        {
            parentLayer.IncludedTasks[_task].TaskRectTransform.sizeDelta = new Vector2(100, 80);
            parentLayer.IncludedTasks[_task].TaskRectTransform.anchoredPosition = Vector2.zero;
            parentLayer.IncludedTasks[_task].gameObject.SetActive(false);
            _task.IsActive = false;
            parentLayer.IncludedTasks.Remove(_task);
        }
    }
}