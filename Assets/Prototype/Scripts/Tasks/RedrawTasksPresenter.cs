using System.Collections.Generic;
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
            _model.VirtualizationModel.ContentScrollPositionChangedHorizontal += OnRedrawTasks;
        }

        private void OnRedrawTasks()
        {
            List<(Task, Layer)> tasksToTurnOff = new List<(Task, Layer)>();
            foreach (var includedLayer in _model.LayersModel.IncludedLayers.Keys)
            {
                foreach (var includedTask in includedLayer.IncludedTasks.Keys)
                {
                    tasksToTurnOff.Add((includedTask, includedLayer));
                }
            }
            foreach (var task in tasksToTurnOff)
            {
                task.Item1.TurnOff(task.Item2);
            }
            
            
            float positionX = -_view.WorkZoneScrollContent.anchoredPosition.x;
            float leftBoard = positionX - 200;
            float rightBoard = positionX + 2000;

            foreach (var layer in _model.LayersModel.IncludedLayers.Keys)
            {
                int leftBoardTaskPositionIndex = layer.GetLeftBoardTaskPosition(leftBoard);
                int rightBoardTaskPositionIndex = layer.GetRightBoardTaskPosition(rightBoard);

                for (int i = leftBoardTaskPositionIndex; i <= rightBoardTaskPositionIndex; i++)
                {
                    layer.Tasks[i].TurnOn(layer);
                }
            }
        }
    }
}