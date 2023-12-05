using System.Collections.Generic;

namespace Prototype.Scripts.TimeScaleDir
{
    public class RedrawTimeScalePresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public RedrawTimeScalePresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }

        public void Subscribe()
        {
            _model.VirtualizationModel.ContentScrollPositionChangedHorizontal += OnRedrawTimeScale;
        }

        public void Unsubscribe()
        {
            _model.VirtualizationModel.ContentScrollPositionChangedHorizontal += OnRedrawTimeScale;
        }

        private void OnRedrawTimeScale()
        {
            float positionX = -_view.TimeScaleContent.anchoredPosition.x;
            float leftBoard = positionX - 200;
            float rightBoard = positionX + 1800;
            
            var toRemove = new HashSet<PartOfTimeScale>(_model.TimeScaleModel.IncludedPartsOfTime.Keys);
            List<PartOfTimeScale> partOfTimeScales = _model.TimeScaleModel.PartsOfTimeScale.GetValuesBetweenBoundaries(leftBoard, rightBoard);
            foreach (var partOfTimeScale in partOfTimeScales)
            {
                if (partOfTimeScale.IsActive)
                {
                    toRemove.Remove(partOfTimeScale);
                }
                else
                {
                    partOfTimeScale.TurnOn();
                }
            }

            foreach (var task in toRemove)
            {
                task.TurnOff();
            }
        }
    }
}