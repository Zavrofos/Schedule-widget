using System.Collections.Generic;
using Prototype.Scripts.Layers;
using Prototype.Scripts.Layers.Tasks;
using UnityEngine;

namespace Prototype.Scripts
{
    public class GeneratePresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public GeneratePresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }
        
        public void Subscribe()
        {
            _view.GenerateButton.onClick.AddListener(OnGenerate);
        }

        public void Unsubscribe()
        {
            _view.GenerateButton.onClick.RemoveListener(OnGenerate);
        }

        private void OnGenerate()
        {
            List<Layer> layersToRemove = new List<Layer>();
            foreach (var layer in _model.LayersModel.Layers)
            {
                List<Task> tasksToRemove = new List<Task>();
                foreach (var task in layer.Tasks)
                {
                    tasksToRemove.Add(task);
                }
                foreach (var task in tasksToRemove)
                {
                    layer.RemoveTask(task);
                }
                
                layersToRemove.Add(layer);
            }

            foreach (var layer in layersToRemove)
            {
                _model.LayersModel.RemoveLayer(layer);
            }
            
            foreach (var layerWindow in _model.LayersModel.PoolLayerWindows.PoolObj)
            {
                GameObject.Destroy(layerWindow.gameObject);
            }

            _model.TasksStatusModel.PendingCount = 0;
            _model.TasksStatusModel.JeopardyCount = 0;
            _model.TasksStatusModel.CompletedCount = 0;
            
            _model.Initialize();
        }
    }
}