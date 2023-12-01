using UnityEngine;

namespace Prototype.Scripts.TimeLine
{
    public class InitializeTimeLinePresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public InitializeTimeLinePresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }

        public void Subscribe()
        {
            _model.Initialized += OnInitializeTimeLine;
        }

        public void Unsubscribe()
        {
            _model.Initialized += OnInitializeTimeLine;
        }

        private void OnInitializeTimeLine()
        {
            float sizeX = _view.ScrollContent.sizeDelta.x;
            float sizeY = _view.ScrollContent.sizeDelta.y;
            
            _view.TimeLineContent.sizeDelta = new Vector2(sizeX, sizeY);
            _view.TimeLine.anchoredPosition = new Vector2(Random.Range(0, sizeX), 0);
        }
    }
}