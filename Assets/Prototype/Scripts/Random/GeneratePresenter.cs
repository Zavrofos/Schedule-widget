using System.Collections.Generic;
using Prototype.Scripts.Layers;
using Prototype.Scripts.Tasks;
using Prototype.Scripts.TimeScaleDir;
using UnityEngine;

namespace Prototype.Scripts.Random
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
                foreach (var task in layer.Value.Tasks)
                {
                    tasksToRemove.Add(task.Value);
                }
                foreach (var task in tasksToRemove)
                {
                    layer.Value.RemoveTask(task);
                }
                
                layersToRemove.Add(layer.Value);
            }
            foreach (var layer in layersToRemove)
            {
                _model.LayersModel.RemoveLayer(layer);
            }
            
            
            foreach (var layerWindow in _model.LayersModel.PoolLayerWindows.PoolObj)
            {
                foreach (var taskWindow in layerWindow.PoolTaskWindows.PoolObj)
                {
                    taskWindow.TaskRectTransform.anchoredPosition = Vector2.zero;
                    taskWindow.TaskRectTransform.sizeDelta = taskWindow.InitialSize;
                    taskWindow.gameObject.SetActive(false);
                }
                layerWindow.RectTransform.anchoredPosition = Vector2.zero;
                layerWindow.gameObject.SetActive(false);
            }

            
            
            foreach (var partOfTimeScale in _model.TimeScaleModel.PartsOfTimeScale)
            {
                if (partOfTimeScale.Value.IsActive)
                {
                    partOfTimeScale.Value.TurnOff();
                }
            }

            
            List<PartOfTimeScale> partOfTimeScalesToRemove = new List<PartOfTimeScale>();
            foreach (var node in _model.TimeScaleModel.PartsOfTimeScale)
            {
                partOfTimeScalesToRemove.Add(node.Value);
            }

            foreach (var partOfTimeScale in partOfTimeScalesToRemove)
            {
                _model.TimeScaleModel.RemovePartOfTimeScale(partOfTimeScale);
            }

            foreach (var partOfTimeScaleWindow in _model.TimeScaleModel.PartOfTimeScalePool.PoolObj)
            {
                if (partOfTimeScaleWindow.gameObject.activeInHierarchy)
                {
                    partOfTimeScaleWindow.PartOfTimeScaleTransform.anchoredPosition = Vector2.zero;
                    partOfTimeScaleWindow.gameObject.SetActive(false);
                }
            }
            
            
            _view.WorkZoneScrollContent.sizeDelta = _model.WorkZoneModel.InitialSize;
            _view.TimeLineContent.sizeDelta = _model.TimeLineModel.InitialSize;
            _view.TimeScaleContent.sizeDelta = _model.TimeScaleModel.InitialSize;
            
            _model.WorkZoneModel.contentSizeX = _view.WorkZoneScrollContent.sizeDelta.x;
            _model.WorkZoneModel.contentSizeY = 0;
            
            _model.TasksStatusModel.PendingCount = 0;
            _model.TasksStatusModel.JeopardyCount = 0;
            _model.TasksStatusModel.CompletedCount = 0;
            
            _model.TimeScaleModel.LastValueTime = 0;
            _model.TimeScaleModel.Initialize();
            
            _model.RandomizeModel.SetRandomLayers();
            _model.TimeLineModel.SetRandomPosition();
            _model.VirtualizationModel.ChangeContentScrollPositionVertical();
            _model.VirtualizationModel.ChangeContentScrollPositionHorizontal();
        }
    }
}