using Prototype.Scripts.Layers;
using UnityEngine;

namespace Prototype.Scripts
{
    public class InitializeModelPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public InitializeModelPresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }
        
        public void Subscribe()
        {
            _model.Initialized += OnInitialize;
        }

        public void Unsubscribe()
        {
            _model.Initialized += OnInitialize;
        }

        private void OnInitialize()
        {
            _model.PoolLayerWindows = new Pool<LayerWindow>(_view.LayerWindowPrefab, _view.ScrollContent, _view.CountLayerPool);
            
            float newHeight = _view.InitialCountLayers * 100;
            _view.ScrollContent.sizeDelta = new Vector2(_view.ScrollContent.sizeDelta.x, newHeight);
            
            for (int i = 0; i < _view.InitialCountLayers; i++)
            {
                _model.LayersModel.Addlayer();
            }
        }
    }
}