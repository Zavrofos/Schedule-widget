using UnityEngine;

namespace Prototype.Scripts.TimeScaleDir
{
    public class SetTimeScaleContentSizeXPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public SetTimeScaleContentSizeXPresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }
        
        public void Subscribe()
        {
            _model.WorkZoneModel.ChangedContentSizeX += OnChangeContentSizeX;
        }
        
        public void Unsubscribe()
        {
            _model.WorkZoneModel.ChangedContentSizeX -= OnChangeContentSizeX;
        }
        
        private void OnChangeContentSizeX(float newSizeX)
        {
            _view.TimeScaleContent.sizeDelta = new Vector2(newSizeX, _view.TimeScaleContent.sizeDelta.y);
            int countPartOfTimeScale = (int) ((100 - (newSizeX % 100)) + newSizeX) / 100 + 17;
            int countPartOfTimeScaleNew = countPartOfTimeScale - _model.TimeScaleModel.LastValueTime;

            for (int i = 0; i < countPartOfTimeScaleNew; i++)
            {
                _model.TimeScaleModel.AddPartOfTimeScale();
            }
        }
    }
}