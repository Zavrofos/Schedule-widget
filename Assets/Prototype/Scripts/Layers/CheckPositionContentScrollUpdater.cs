using UnityEngine;

namespace Prototype.Scripts.Layers
{
    public class CheckPositionContentScrollUpdater : IUpdater
    {
        private readonly Model _model;
        private readonly View _view;
        private float _currentPositionContent = 0;

        public CheckPositionContentScrollUpdater(Model model, View view)
        {
            _model = model;
            _view = view;
        }

        public void Update(float deltaTime)
        {
            if (Mathf.Abs(_currentPositionContent - _view.ScrollContent.anchoredPosition.y) > 100)
            {
                _model.ChangeContentScrollPosition();
                _currentPositionContent = _view.ScrollContent.anchoredPosition.y - _view.ScrollContent.anchoredPosition.y % 100;
            }
        }
    }
}