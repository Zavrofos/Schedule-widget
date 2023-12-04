using System.Collections.Generic;
using Prototype.Scripts.Tasks;

namespace Prototype.Scripts.Layers
{
    public class AddingLayerPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;
        private Dictionary<Layer, List<IPresenter>> LayersPresenters;

        public AddingLayerPresenter(Model model, View view)
        {
            _model = model;
            _view = view;
            LayersPresenters = new Dictionary<Layer, List<IPresenter>>();
        }
        
        public void Subscribe()
        {
            _model.LayersModel.AddedLayer += OnAddNewLayer;
            _model.LayersModel.RemovedLayer += OnRemoveLayer;
        }

        public void Unsubscribe()
        {
            _model.LayersModel.AddedLayer -= OnAddNewLayer;
            _model.LayersModel.RemovedLayer -= OnRemoveLayer;
        }

        private void OnAddNewLayer()
        {
            float initialPositionLayer;
            if (_model.LayersModel.Layers.Root == null)
            {
                initialPositionLayer = 0;
            }
            else
            {
                initialPositionLayer = _model.LayersModel.PreviousLayer.InitialPosition +
                                       _view.LayerWindowPrefab.RectTransform.sizeDelta.y;
            }
            
            _model.WorkZoneModel.ChangeContentSizeY(_model.WorkZoneModel.contentSizeY + _view.LayerWindowPrefab.RectTransform.sizeDelta.y);
            
            Layer newLayer = new Layer(initialPositionLayer);
            _model.LayersModel.PreviousLayer = newLayer;
            _model.LayersModel.Layers.Add(initialPositionLayer, newLayer);

            List<IPresenter> presenters = new List<IPresenter>()
            {
                new TurningOnLayerPresenter(_model, newLayer, _view),
                new TurningOffLayerPresenter(_model, newLayer, _view),
                new AddingTasksPresenter(_model, newLayer, _view),
                new SettingStateTasksInLayerPresenter(_model, newLayer, _view),
                new RedrawTasksPresenter(_model, newLayer, _view)
            };

            foreach (var presenter in presenters)
            {
                presenter.Subscribe();
            }
            
            LayersPresenters.Add(newLayer, presenters);
        }

        private void OnRemoveLayer(Layer layer)
        {
            foreach (var presenters in LayersPresenters[layer])
            {
               presenters.Unsubscribe();
            }

            LayersPresenters.Remove(layer);
            
            if (layer.IsActive)
            {
                _model.LayersModel.IncludedLayers.Remove(layer);
            }
            
            _model.LayersModel.Layers.Delete(layer.InitialPosition);
        }
    }
}