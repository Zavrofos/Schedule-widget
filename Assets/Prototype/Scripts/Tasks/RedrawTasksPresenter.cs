using UnityEngine;

namespace Prototype.Scripts.Tasks
{
    public class RedrawTasksPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public RedrawTasksPresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }
        
        public void Subscribe()
        {
            _model.VirtualizationModel.ContentScrollPositionChangedHorizontal += OnRedrawTasks;
        }

        public void Unsubscribe()
        {
            _model.VirtualizationModel.ContentScrollPositionChangedHorizontal += OnRedrawTasks;
        }

        private void OnRedrawTasks()
        {
            foreach (var includedLayer in _model.LayersModel.IncludedLayers.Keys)
            {
                foreach (var task in includedLayer.Tasks)
                {
                    float sizeTask = task.EndTime - task.StartTime;
                    float positionTask = task.StartTime + (sizeTask / 2);

                    if (positionTask > Mathf.Abs(_view.WorkZoneScrollContent.anchoredPosition.x) - 200 &&
                        positionTask < Mathf.Abs(_view.WorkZoneScrollContent.anchoredPosition.x) + 2000)
                    {
                        if (!task.IsActive)
                        {
                            task.TurnOn(includedLayer);
                        }
                    }
                    else
                    {
                        if (task.IsActive)
                        {
                            task.TurnOff(includedLayer);
                        }
                    }
                }
            }
        }
    }
}