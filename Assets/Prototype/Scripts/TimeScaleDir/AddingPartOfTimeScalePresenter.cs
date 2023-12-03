using UnityEngine;

namespace Prototype.Scripts.TimeScaleDir
{
    public class AddingPartOfTimeScalePresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public AddingPartOfTimeScalePresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }
        
        public void Subscribe()
        {
            _model.TimeScaleModel.AddedpartOfTimeScale += OnAddPartOfTimeScale;
        }

        public void Unsubscribe()
        {
            _model.TimeScaleModel.AddedpartOfTimeScale += OnAddPartOfTimeScale;
        }

        private void OnAddPartOfTimeScale()
        {
            PartOfTimeScale partOfTimeScale =
                GameObject.Instantiate(_view.PartOfTimeScalePrefab, _view.TimeScaleContent);
            partOfTimeScale.PartOfTimeText.text = (_model.TimeScaleModel.LastValueTime * 10).ToString();
            _model.TimeScaleModel.LastValueTime++;
            _model.TimeScaleModel.PartsOfTimeScale.Add(partOfTimeScale);
        }
    }
}