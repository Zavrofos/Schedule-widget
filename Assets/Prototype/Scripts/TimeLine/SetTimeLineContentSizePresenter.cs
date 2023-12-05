namespace Prototype.Scripts.TimeLine
{
    public class SetTimeLineContentSizePresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public SetTimeLineContentSizePresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }
        
        public void Subscribe()
        {
            _model.WorkZoneModel.ChangedContentSizeX += OnChangeContentSize;
            _model.WorkZoneModel.ChangedContentSizeY += OnChangeContentSize;
        }

        public void Unsubscribe()
        {
            _model.WorkZoneModel.ChangedContentSizeX -= OnChangeContentSize;
            _model.WorkZoneModel.ChangedContentSizeY -= OnChangeContentSize;
        }

        private void OnChangeContentSize(float newSizeXY)
        {
            _view.TimeLineContent.sizeDelta = _view.WorkZoneScrollContent.sizeDelta;
        }
    }
}