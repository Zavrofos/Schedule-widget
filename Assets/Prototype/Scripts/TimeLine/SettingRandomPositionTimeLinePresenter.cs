using UnityEngine;

namespace Prototype.Scripts.TimeLine
{
    public class SettingRandomPositionTimeLinePresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public SettingRandomPositionTimeLinePresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }

        public void Subscribe()
        {
            _model.TimeLineModel.SetedRandomPosition += OnSetRandomPosition;
        }

        public void Unsubscribe()
        {
            _model.TimeLineModel.SetedRandomPosition -= OnSetRandomPosition;
        }

        private void OnSetRandomPosition()
        {
            float sizeX = _view.WorkZoneScrollContent.sizeDelta.x;
            
            _view.TimeLine.anchoredPosition = new Vector2(UnityEngine.Random.Range(0, sizeX), 0);
            _model.TimeLineModel.CurrentPositinX = _view.TimeLine.anchoredPosition.x;
            
            foreach (var layer in _model.LayersModel.Layers)
            {
                layer.Value.SetStateTasks();
            }

            _view.PendingCountText.text = _model.TasksStatusModel.PendingCount.ToString();
            _view.JeopardyCountText.text = _model.TasksStatusModel.JeopardyCount.ToString();
            _view.CompletedCountText.text = _model.TasksStatusModel.CompletedCount.ToString();
        }
    }
}