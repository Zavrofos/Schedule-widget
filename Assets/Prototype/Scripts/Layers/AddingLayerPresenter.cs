using System.Collections.Generic;
using Prototype.Scripts.Layers.Tasks;

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
        }

        public void Unsubscribe()
        {
            _model.LayersModel.AddedLayer -= OnAddNewLayer;
        }

        private void OnAddNewLayer()
        {
            Layer newLayer;
            
            if (_model.LayersModel.Layers.Count == 0)
                newLayer = new Layer(0);
            else
                newLayer = new Layer(_model.LayersModel.Layers[_model.LayersModel.Layers.Count - 1].InitialPosition + 100);
            
            _model.LayersModel.Layers.Add(newLayer);

            List<IPresenter> presenters = new List<IPresenter>()
            {
                new TurningOnLayerPresenter(_model, newLayer, _view),
                new TurningOffLayerPresenter(_model, newLayer, _view),
                new AddingTasksPresenter(_model, newLayer, _view)
            };

            foreach (var presenter in presenters)
            {
                presenter.Subscribe();
            }
            
            LayersPresenters.Add(newLayer, presenters);
        }
    }
}