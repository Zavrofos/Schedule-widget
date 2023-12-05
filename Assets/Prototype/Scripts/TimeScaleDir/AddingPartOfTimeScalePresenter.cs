using System.Collections.Generic;

namespace Prototype.Scripts.TimeScaleDir
{
    public class AddingPartOfTimeScalePresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;
        private Dictionary<PartOfTimeScale, List<IPresenter>> PartsOfTimeScalePresenters;

        public AddingPartOfTimeScalePresenter(Model model, View view)
        {
            _model = model;
            _view = view;
            PartsOfTimeScalePresenters = new Dictionary<PartOfTimeScale, List<IPresenter>>();
        }
        
        public void Subscribe()
        {
            _model.TimeScaleModel.AddedPartOfTimeScale += OnAddPartOfTimeScale;
            _model.TimeScaleModel.RemovedPartOfTimeScale += OnRemovepartOfTimeScale;
        }

        public void Unsubscribe()
        {
            _model.TimeScaleModel.AddedPartOfTimeScale += OnAddPartOfTimeScale;
            _model.TimeScaleModel.RemovedPartOfTimeScale -= OnRemovepartOfTimeScale;
        }
        
        private void OnAddPartOfTimeScale()
        {
            PartOfTimeScale partOfTimeScale = new PartOfTimeScale(_model.TimeScaleModel.LastValueTime * _view.partOfTimeScaleWindowPrefab.PartOfTimeScaleTransform.sizeDelta.x);
            _model.TimeScaleModel.PartsOfTimeScale.Add(partOfTimeScale.Position, partOfTimeScale);
            _model.TimeScaleModel.LastValueTime++;

            List<IPresenter> presenters = new List<IPresenter>()
            {
                new TurnOnOffPartOfTimeScalePresenter(_model, partOfTimeScale, _view)
            };

            foreach (var presenter in presenters)
            {
                presenter.Subscribe();
            }
            
            PartsOfTimeScalePresenters.Add(partOfTimeScale, presenters);
        }
        
        private void OnRemovepartOfTimeScale(PartOfTimeScale partOfTimeScale)
        {
            foreach (var presenter in PartsOfTimeScalePresenters[partOfTimeScale])
            {
                presenter.Unsubscribe();
            }

            PartsOfTimeScalePresenters.Remove(partOfTimeScale);

            if (partOfTimeScale.IsActive)
            {
                _model.TimeScaleModel.IncludedPartsOfTime.Remove(partOfTimeScale);
            }
            
            _model.TimeScaleModel.PartsOfTimeScale.Delete(partOfTimeScale.Position);
        }
    }
}