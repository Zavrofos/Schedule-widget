using UnityEngine;

namespace Prototype.Scripts.WorkZone
{
    public class SetContentWorkZoneSizePresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public SetContentWorkZoneSizePresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }

        public void Subscribe()
        {
            _model.WorkZoneModel.ChangedContentSizeX += OnChangeContentSizeX;
            _model.WorkZoneModel.ChangedContentSizeY += OnChangeContentSizeY;
        }

        public void Unsubscribe()
        {
            _model.WorkZoneModel.ChangedContentSizeX -= OnChangeContentSizeX;
            _model.WorkZoneModel.ChangedContentSizeY -= OnChangeContentSizeY;
        }
        
        private void OnChangeContentSizeX(float newSizeX)
        {
            _view.WorkZoneScrollContent.sizeDelta = new Vector2(newSizeX, _view.WorkZoneScrollContent.sizeDelta.y);
            _model.WorkZoneModel.contentSizeX = newSizeX;
        }
        
        private void OnChangeContentSizeY(float newSizeY)
        {
            _view.WorkZoneScrollContent.sizeDelta = new Vector2(_view.WorkZoneScrollContent.sizeDelta.x, newSizeY);
            _model.WorkZoneModel.contentSizeY = newSizeY;
        }
    }
}