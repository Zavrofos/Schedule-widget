using UnityEngine;

namespace Prototype.Scripts.TimeScaleDir
{
    public class InitializeTimeScalePresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public InitializeTimeScalePresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }
        
        public void Subscribe()
        {
            _model.TimeScaleModel.Initialized += OnInitialize;
        }

        public void Unsubscribe()
        {
            _model.TimeScaleModel.Initialized -= OnInitialize;
        }

        private void OnInitialize()
        {
            int countPartOfTimeScale = (int)((100 - (_view.TimeScaleContent.rect.size.x % 100)) + _view.TimeScaleContent.rect.size.x) / 100;
            
            for (int i = 0; i < countPartOfTimeScale; i++)
            {
                _model.TimeScaleModel.AddPartOfTimeScale();
            }
        }
    }
}