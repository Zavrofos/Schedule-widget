using UnityEngine;

namespace Prototype.Scripts.TimeScaleDir
{
    public class TurnOnOffPartOfTimeScalePresenter : IPresenter
    {
        private readonly Model _model;
        private readonly PartOfTimeScale _partOfTimeScale;
        private readonly View _view;

        public TurnOnOffPartOfTimeScalePresenter(Model model, PartOfTimeScale partOfTimeScale, View view)
        {
            _model = model;
            _partOfTimeScale = partOfTimeScale;
            _view = view;
        }
        
        public void Subscribe()
        {
            _partOfTimeScale.TurnedOn += OnTurnOn;
            _partOfTimeScale.TurnedOff += OnTurnOff;
        }

        public void Unsubscribe()
        {
            _partOfTimeScale.TurnedOn -= OnTurnOn;
            _partOfTimeScale.TurnedOff -= OnTurnOff;
        }
        
        private void OnTurnOn()
        {
            PartOfTimeScaleWindow partOfTimeScaleWindow = _model.TimeScaleModel.PartOfTimeScalePool.GetFreeElement();
            partOfTimeScaleWindow.PartOfTimeScaleTransform.anchoredPosition = new Vector2(_partOfTimeScale.Position, 0);
            partOfTimeScaleWindow.PartOfTimeText.text = (_partOfTimeScale.Position / 10).ToString();
            _model.TimeScaleModel.IncludedPartsOfTime.Add(_partOfTimeScale, partOfTimeScaleWindow);
            _partOfTimeScale.IsActive = true;
        }
        
        private void OnTurnOff()
        {
            _model.TimeScaleModel.IncludedPartsOfTime[_partOfTimeScale].PartOfTimeScaleTransform.anchoredPosition =
                new Vector2(0,
                    _model.TimeScaleModel.IncludedPartsOfTime[_partOfTimeScale].PartOfTimeScaleTransform
                        .anchoredPosition.y);
            _model.TimeScaleModel.IncludedPartsOfTime[_partOfTimeScale].gameObject.SetActive(false);
            _partOfTimeScale.IsActive = false;
            _model.TimeScaleModel.IncludedPartsOfTime.Remove(_partOfTimeScale);
        }
    }
}