using Prototype.Scripts.Tasks;

namespace Prototype.Scripts.Layers
{
    public class SettingStateTasksInLayerPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly Layer _layer;
        private readonly View _view;

        public SettingStateTasksInLayerPresenter(Model model, Layer layer, View view)
        {
            _model = model;
            _layer = layer;
            _view = view;
        }

        public void Subscribe()
        {
            _layer.SettedStateTasks += OnSetStateTasks;
        }

        public void Unsubscribe()
        {
            _layer.SettedStateTasks += OnSetStateTasks;
        }

        private void OnSetStateTasks()
        {
            foreach (var task in _layer.Tasks)
            {
                if (task.EndTime < _model.TimeLineModel.CurrentPositinX)
                {
                    int completedChance = UnityEngine.Random.Range(90, 100);
                    int jeopardyChance = UnityEngine.Random.Range(0, 100);
            
                    if (jeopardyChance > completedChance)
                    {
                        task.CurrentState = StateTask.Jeopardy;
                        _model.TasksStatusModel.JeopardyCount++;
                    }
                    else
                    {
                        task.CurrentState = StateTask.Completed;
                        _model.TasksStatusModel.CompletedCount++;
                    }
                }
                else
                {
                    task.CurrentState = StateTask.Pending;
                    _model.TasksStatusModel.PendingCount++;
                }
            }
        }
    }
}
