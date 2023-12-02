using System.Collections.Generic;

namespace Prototype.Scripts.Layers.Tasks
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
            _layer.UnsubscribedTaskPresenters += UnsubscribeTaskPresentersPresenters;

        }

        public void Unsubscribe()
        {
            _layer.AddedTask -= OnAddTask;
            _layer.UnsubscribedTaskPresenters -= UnsubscribeTaskPresentersPresenters;
        }

        private void OnAddTask(int startTime, int endTime)
        {
            Task newTask = new Task(startTime, endTime, _layer);

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
        }

        private void UnsubscribeTaskPresentersPresenters(Task task)
        {
            foreach (var presenter in TasksPresenters[task])
            {
                presenter.Unsubscribe();
            }

            TasksPresenters.Remove(task);
        }
    }
}