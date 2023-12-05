namespace Prototype.Scripts.Layers
{
    public class AddNewLayerButtonPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public AddNewLayerButtonPresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }

        public void Subscribe()
        {
            _view.AddNewLayerButton.onClick.AddListener(OnAddNewLayer);
        }

        public void Unsubscribe()
        {
            _view.AddNewLayerButton.onClick.RemoveListener(OnAddNewLayer);
        }

        private void OnAddNewLayer()
        {
            int countTasks = 0;
            if (int.TryParse(_view.CountElementsInNewLayerText.text, out countTasks))
            {
                if (countTasks <= 0)
                {
                    return;
                }
                
                if (countTasks > _view.MaxTasksInLayer)
                {
                    countTasks = _view.MaxTasksInLayer;
                    _view.CountElementsInNewLayerText.text = _view.MaxTasksInLayer.ToString();
                }
                
                _model.LayersModel.Addlayer();
                Layer newLayer = _model.LayersModel.Layers[_model.LayersModel.Layers.Count - 1];
            
                _model.RandomizeModel.RandomFillLayer(newLayer, (int)countTasks);
                newLayer.SetStateTasks();
            
                _view.PendingCountText.text = _model.TasksStatusModel.PendingCount.ToString();
                _view.JeopardyCountText.text = _model.TasksStatusModel.JeopardyCount.ToString();
                _view.CompletedCountText.text = _model.TasksStatusModel.CompletedCount.ToString();
            }
        }
    }
}