using Prototype.Scripts.Layers;
using UnityEngine;

namespace Prototype.Scripts.Random
{
    public class SetRandomLayersPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public SetRandomLayersPresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }
        
        public void Subscribe()
        {
            _model.RandomizeModel.SettedRandomLayers += OnSetRandomLayers;
        }

        public void Unsubscribe()
        {
            _model.RandomizeModel.SettedRandomLayers -= OnSetRandomLayers;
        }

        private void OnSetRandomLayers()
        {
            int countRandomLayers = UnityEngine.Random.Range(20, 40);
            int countRandomTask = UnityEngine.Random.Range(10, 100);

            for (int i = 0; i < countRandomLayers; i++)
            {
                _model.LayersModel.Addlayer();
                Layer newLayer = _model.LayersModel.PreviousLayer;
                float key = _model.LayersModel.Layers.Root.Key;
                _model.RandomizeModel.RandomFillLayer(newLayer, countRandomTask);
            }
        }
    }
}