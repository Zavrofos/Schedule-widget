using UnityEngine;

namespace Prototype.Scripts
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
            if (Mathf.Abs(_currentPositionContentVertical - _view.WorkZoneScrollContent.anchoredPosition.y) > 100)
            {
                _model.VirtualizationModel.ChangeContentScrollPositionVertical();
                _currentPositionContentVertical = _view.WorkZoneScrollContent.anchoredPosition.y -
                                                  _view.WorkZoneScrollContent.anchoredPosition.y % 100;
            }

            if (Mathf.Abs(_currentLeftBoardValue - Mathf.Abs(_view.WorkZoneScrollContent.anchoredPosition.x)) > 100)
            {
                _model.VirtualizationModel.ChangeContentScrollPositionHorizontal();
                _currentLeftBoardValue = Mathf.Abs(_view.WorkZoneScrollContent.anchoredPosition.x) -
                                         Mathf.Abs(_view.WorkZoneScrollContent.anchoredPosition.x) % 100;
            }
        }
    }
}