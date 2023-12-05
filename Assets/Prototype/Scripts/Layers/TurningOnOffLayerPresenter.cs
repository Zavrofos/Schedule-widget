using System.Collections.Generic;
using Prototype.Scripts.Tasks;
using UnityEngine;

namespace Prototype.Scripts.Layers
{
    public class TurningOnOffLayerPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly Layer _layer;
        private readonly View _view;

        public TurningOnOffLayerPresenter(Model model, Layer layer, View view)
        {
            _model = model;
            _layer = layer;
            _view = view;
        }

        public void Subscribe()
        {
            _layer.TurnedOn += OnTurnOn;
            _layer.TurnedOff += OnTurnOff;
        }

        public void Unsubscribe()
        {
            _layer.TurnedOn += OnTurnOn;
            _layer.TurnedOff -= OnTurnOff;
        }
        
        private void OnTurnOn()
        {
            LayerWindow layerWindow = _model.LayersModel.PoolLayerWindows.GetFreeElement();
            var anchoredPosition = layerWindow.RectTransform.anchoredPosition;
            anchoredPosition = new Vector3(0, -_layer.InitialPosition, 0);
            layerWindow.RectTransform.anchoredPosition = anchoredPosition;

            _layer.IsActive = true;
            _model.LayersModel.IncludedLayers.Add(_layer, layerWindow);
        }
        
        private void OnTurnOff()
        {
            List<Task> tasksForTurnOff = new List<Task>();
            foreach (var includedTask in _layer.IncludedTasks.Keys)
            {
                tasksForTurnOff.Add(includedTask);
            }

            foreach (var includedTask in tasksForTurnOff)
            {
                includedTask.TurnOff(_layer);
            }

            _layer.IsActive = false;
            _model.LayersModel.IncludedLayers[_layer].RectTransform.anchoredPosition = Vector2.zero;
            _model.LayersModel.IncludedLayers[_layer].gameObject.SetActive(false);
            _model.LayersModel.IncludedLayers.Remove(_layer);
        }
    }
}