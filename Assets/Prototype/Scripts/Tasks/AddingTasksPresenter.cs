﻿using System.Collections.Generic;
using Prototype.Scripts.Layers;

namespace Prototype.Scripts.Tasks
{
    public class AddingTasksPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly Layer _layer;
        private readonly View _view;
        private Dictionary<Task, List<IPresenter>> TasksPresenters;

        public AddingTasksPresenter(Model model, Layer layer, View view)
        {
            _model = model;
            _layer = layer;
            _view = view;
            TasksPresenters = new Dictionary<Task, List<IPresenter>>();
        }

        public void Subscribe()
        {
            _layer.AddedTask += OnAddTask;
            _layer.RemovedTask += OnRemoveTask;

        }

        public void Unsubscribe()
        {
            _layer.AddedTask -= OnAddTask;
            _layer.RemovedTask -= OnRemoveTask;
        }

        private void OnAddTask(int startTime, int endTime)
        {
            Task newTask = new Task(startTime, endTime);
            _layer.PreviousTask = newTask;

            if (endTime - _model.WorkZoneModel.RightBordermargin > _model.WorkZoneModel.contentSizeX)
            {
                _model.WorkZoneModel.ChangeContentSizeX(endTime - _model.WorkZoneModel.RightBordermargin);
            }

            List<IPresenter> presenters = new List<IPresenter>()
            {
                new TurningOnOffTaskPresenter(_model, newTask, _view),
            };

            foreach (var presenter in presenters)
            {
                presenter.Subscribe();
            }
            
            TasksPresenters.Add(newTask, presenters);
            
            _layer.Tasks.Add(newTask.StartTime, newTask);
        }

        private void OnRemoveTask(Task task)
        {
            foreach (var presenter in TasksPresenters[task])
            {
                presenter.Unsubscribe();
            }

            TasksPresenters.Remove(task);

            if (task.IsActive)
            {
                _layer.IncludedTasks.Remove(task);
            }

            _layer.Tasks.Delete(task.StartTime);
        }
    }
}