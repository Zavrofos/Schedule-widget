using UnityEngine;

namespace Prototype.Scripts.Layers.Tasks
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
            _model.ContentScrollPositionChangedHorizontal += OnRedrawTasks;
        }

        public void Unsubscribe()
        {
            _model.ContentScrollPositionChangedHorizontal += OnRedrawTasks;
        }

        private void OnRedrawTasks()
        {
            foreach (var includedLayer in _model.LayersModel.IncludedLayers.Keys)
            {
                foreach (var task in includedLayer.Tasks)
                {
                    float sizeTask = task.EndTime - task.StartTime;
                    float positionTask = task.StartTime + (sizeTask / 2);

                    if (positionTask > Mathf.Abs(_view.ScrollContent.anchoredPosition.x) - 200 &&
                        positionTask < Mathf.Abs(_view.ScrollContent.anchoredPosition.x) + 2000)
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