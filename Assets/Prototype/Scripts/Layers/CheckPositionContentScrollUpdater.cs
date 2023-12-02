using UnityEngine;

namespace Prototype.Scripts.Layers
{
    public class CheckPositionContentScrollUpdater : IUpdater
    {
        private readonly Model _model;
        private readonly View _view;
        private float _currentPositionContentVertical = 0;
        private float _currentLeftBoardValue = 0;

        public CheckPositionContentScrollUpdater(Model model, View view)
        {
            _model = model;
            _view = view;
        }



        public void Update(float deltaTime)
        {
            if (Mathf.Abs(_currentPositionContentVertical - _view.ScrollContent.anchoredPosition.y) > 100)
            {
                _model.VirtualizationModel.ChangeContentScrollPositionVertical();
                _currentPositionContentVertical = _view.ScrollContent.anchoredPosition.y -
                                                  _view.ScrollContent.anchoredPosition.y % 100;
            }

            if (Mathf.Abs(_currentLeftBoardValue - Mathf.Abs(_view.ScrollContent.anchoredPosition.x)) > 100)
            {
                _model.VirtualizationModel.ChangeContentScrollPositionHorizontal();
                _currentLeftBoardValue = Mathf.Abs(_view.ScrollContent.anchoredPosition.x) -
                                         Mathf.Abs(_view.ScrollContent.anchoredPosition.x) % 100;
            }
        }
    }
}