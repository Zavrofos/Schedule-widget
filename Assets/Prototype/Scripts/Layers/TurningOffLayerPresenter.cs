using System.Collections.Generic;
using Prototype.Scripts.Tasks;
using UnityEngine;

namespace Prototype.Scripts.Layers
{
    public class TurningOffLayerPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly Layer _layer;
        private readonly View _view;

        public TurningOffLayerPresenter(Model model, Layer layer, View view)
        {
            _model = model;
            _layer = layer;
            _view = view;
        }
        
        public void Subscribe()
        {
            _layer.TurnedOff += OnTurnOff;
        }

        public void Unsubscribe()
        {
            _layer.TurnedOff += OnTurnOff;
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