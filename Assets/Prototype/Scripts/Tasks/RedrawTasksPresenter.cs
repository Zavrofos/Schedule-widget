using System.Collections.Generic;
using System.Linq;
using Prototype.Scripts.Layers;
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
            _model.VirtualizationModel.ContentScrollPositionChangedHorizontal -= OnRedrawTasks;
        }

        private void OnRedrawTasks()
        {
            float positionX = -_view.WorkZoneScrollContent.anchoredPosition.x;
            float leftBoard = positionX - _model.WorkZoneModel.LeftBorderMargin;
            float rightBoard = positionX + _model.WorkZoneModel.RightBordermargin;


            foreach (var includedLayer in _model.LayersModel.IncludedLayers.Keys)
            {
                var toRemove = new HashSet<Task>(includedLayer.IncludedTasks.Keys);
                List<Task> tasks = includedLayer.Tasks.GetValuesBetweenBoundaries(leftBoard, rightBoard);
                foreach (var task in tasks)
                {
                    if (task.IsActive)
                    {
                        toRemove.Remove(task);
                    }
                    else
                    {
                        task.TurnOn(includedLayer);
                    }
                }

                foreach (var task in toRemove)
                {
                    task.TurnOff(includedLayer);
                }
            }
        }
    }
}