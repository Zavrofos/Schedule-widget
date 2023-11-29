namespace Prototype.Scripts.Layers
{
    public class RedrawLayersPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public RedrawLayersPresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }

        public void Subscribe()
        {
            _model.ContentScrollPositionChanged += OnRedrawLayers;
        }

        public void Unsubscribe()
        {
            _model.ContentScrollPositionChanged -= OnRedrawLayers;
        }

        private void OnRedrawLayers()
        {
            foreach (var layer in _model.LayersModel.Layers)
            {
                if ((layer.InitialPosition + 200 + 100) > _view.ScrollContent.anchoredPosition.y &&
                    (_view.ScrollContent.anchoredPosition.y + 1000) > layer.InitialPosition)
                {
                    if (!layer.IsActive)
                    {
                        layer.TurnOn();
                    }
                }
                else
                {
                    if (layer.IsActive)
                    {
                        layer.TurnOff();
                    }
                }
            }
        }
    }
}