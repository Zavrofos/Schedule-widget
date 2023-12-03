using System.Collections.Generic;
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

            if (endTime - 1700 > _model.WorkZoneModel.contentSizeX)
            {
                _model.WorkZoneModel.ChangeContentSizeX(endTime - 1700);
            }

            List<IPresenter> presenters = new List<IPresenter>()
            {
                new TurningOnTaskPresenter(_model, newTask, _view),
                new TurningOffTaskPresenter(_model, newTask, _view)
            };

            foreach (var presenter in presenters)
            {
                presenter.Subscribe();
            }
            
            TasksPresenters.Add(newTask, presenters);
            
            _layer.Tasks.Add(newTask);
            _layer.TasksPositions.Add((startTime, endTime));
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

            _layer.Tasks.Remove(task);
        }
    }
}