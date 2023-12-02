using Prototype.Scripts.Layers.Tasks;
using UnityEngine;

namespace Prototype.Scripts.TimeLine
{
    public class InitializeTimeLinePresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public InitializeTimeLinePresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }

        public void Subscribe()
        {
            _model.Initialized += OnInitializeTimeLine;
        }

        public void Unsubscribe()
        {
            _model.Initialized += OnInitializeTimeLine;
        }

        private void OnInitializeTimeLine()
        {
            float sizeX = _view.ScrollContent.sizeDelta.x;
            float sizeY = _view.ScrollContent.sizeDelta.y;
            
            _view.TimeLineContent.sizeDelta = new Vector2(sizeX, sizeY);
            _view.TimeLine.anchoredPosition = new Vector2(Random.Range(0, sizeX), 0);

            
            
            foreach (var layer in _model.LayersModel.Layers)
            {
                foreach (var task in layer.Tasks)
                {
                    if (task.EndTime < _view.TimeLine.anchoredPosition.x)
                    {
                        int completedChance = Random.Range(90, 100);
                        int jeopardyChance = Random.Range(0, 100);
            
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

            _view.PendingCountText.text = _model.TasksStatusModel.PendingCount.ToString();
            _view.JeopardyCountText.text = _model.TasksStatusModel.JeopardyCount.ToString();
            _view.CompletedCountText.text = _model.TasksStatusModel.CompletedCount.ToString();
        }
    }
}