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
            _model.LayersModel.Addlayer();
            Layer newLayer = _model.LayersModel.Layers[_model.LayersModel.Layers.Count - 1];

            float countTasks = 0;
            string text = "";
            foreach (var ch in _view.CountElementsInNewLayerText.text)
            {
                if (char.IsDigit(ch))
                {
                    text += ch;
                }
            }

            if (float.TryParse(text, out countTasks))
            {
                if (countTasks > _view.MaxTasksInLayer)
                {
                    countTasks = _view.MaxTasksInLayer;
                }
                else if (countTasks <= 0)
                {
                    countTasks = 0;
                }
            }
            
            _model.RandomizeModel.RandomFillLayer(newLayer, (int)countTasks);
            newLayer.SetStateTasks();
            
            _view.PendingCountText.text = _model.TasksStatusModel.PendingCount.ToString();
            _view.JeopardyCountText.text = _model.TasksStatusModel.JeopardyCount.ToString();
            _view.CompletedCountText.text = _model.TasksStatusModel.CompletedCount.ToString();
        }
    }
}