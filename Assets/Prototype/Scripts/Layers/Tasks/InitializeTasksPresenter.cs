using UnityEngine;

namespace Prototype.Scripts.Layers.Tasks
{
    public class InitializeTasksPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public InitializeTasksPresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }

        public void Subscribe()
        {
            _model.Initialized += OnInitializeTasks;
        }

        public void Unsubscribe()
        {
            _model.Initialized += OnInitializeTasks;
        }

        private void OnInitializeTasks()
        {
            int contentScrollSizeX = 0;
            
            foreach (var layer in _model.LayersModel.Layers)
            {
                int countTasks = Random.Range(10, 100);

                for (int i = 0; i < countTasks; i++)
                {
                    int startTime;
                    int endTime;
                
                    if (layer.Tasks.Count == 0)
                    {
                        startTime = 0;
                    }
                    else
                    {
                        int endTimeLastTask = layer.Tasks[layer.Tasks.Count - 1].EndTime;
                        startTime = Random.Range(endTimeLastTask + 50, endTimeLastTask + 350);
                    }

                    endTime = Random.Range(startTime + 100, startTime + 400);
                    if (contentScrollSizeX < endTime) contentScrollSizeX = endTime;
                    
                    layer.AddTask(startTime, endTime);
                }
            }

            contentScrollSizeX -= 1700;
            _view.ScrollContent.sizeDelta = new Vector2(contentScrollSizeX, _view.ScrollContent.sizeDelta.y);
        }
    }
}