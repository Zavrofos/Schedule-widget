using Prototype.Scripts.Layers;
using Prototype.Scripts.Tasks;
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
            _model.LayersModel.PoolLayerWindows = new Pool<LayerWindow>(_view.LayerWindowPrefab, _view.WorkZoneScrollContent, _view.CountLayerPool);

            foreach (var layerWindow in _model.LayersModel.PoolLayerWindows.PoolObj)
            {
                layerWindow.PoolTaskWindows = new Pool<TaskWindow>(_view.TaskWindowPrefab, layerWindow.RectTransform, _view.CountTaskPool);
            }

            _model.WorkZoneModel.contentSizeX = _view.WorkZoneScrollContent.sizeDelta.x;

            _model.WorkZoneModel.InitialSize = _view.WorkZoneScrollContent.sizeDelta;
            _model.TimeLineModel.InitialSize = _view.TimeLineContent.sizeDelta;
            _model.TimeScaleModel.InitialSize = _view.TimeScaleContent.sizeDelta;
        }
    }
}