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

        private void OnTurnOff(Layer layer)
        {
            foreach (var task in layer.Tasks)
            {
                if (task.IsActive)
                {
                    task.TurnOff();
                }
            }
            
            layer.LayerWindow.RectTransform.anchoredPosition = Vector2.zero;
            layer.LayerWindow.gameObject.SetActive(false);
            layer.LayerWindow = null;

            _model.LayersModel.IncludedLayers.Remove(layer);
        }
    }
}