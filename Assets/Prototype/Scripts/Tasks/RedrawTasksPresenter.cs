using System.Collections.Generic;
using System.Linq;
using Prototype.Scripts.Layers;
using UnityEngine;

namespace Prototype.Scripts.Tasks
{
    public class RedrawTasksPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly Layer _layer;
        private readonly View _view;

        public RedrawTasksPresenter(Model model, Layer layer, View view)
        {
            _model = model;
            _layer = layer;
            _view = view;
        }

        public void Subscribe()
        {
            _layer.TurnedOn += OnRedrawTasks;
        }

        public void Unsubscribe()
        {
            _layer.TurnedOn -= OnRedrawTasks;
        }

        private void OnRedrawTasks()
        {
            float positionX = -_view.WorkZoneScrollContent.anchoredPosition.x;
            float leftBoard = positionX - 200;
            float rightBoard = positionX + 1800;
            
            var toRemove = new HashSet<Task>(_layer.IncludedTasks.Keys);
            List<Task> tasks = _layer.Tasks.GetValuesBetweenBoundaries(leftBoard, rightBoard);
            foreach (var task in tasks)
            {
                if (task.IsActive)
                {
                    toRemove.Remove(task);
                }
                else
                {
                    task.TurnOn(_layer);
                }
            }

            foreach (var task in toRemove)
            {
                task.TurnOff(_layer);
            }
        }
    }
}