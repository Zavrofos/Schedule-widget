using Prototype.Scripts.Layers;
using UnityEngine;

namespace Prototype.Scripts.Random
{
    public class RandomTaskFillerPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly View _view;

        public RandomTaskFillerPresenter(Model model, View view)
        {
            _model = model;
            _view = view;
        }
        
        public void Subscribe()
        {
            _model.RandomizeModel.RandomlyFilledTheLayer += OnFillLayerRandom;
        }

        public void Unsubscribe()
        {
            _model.RandomizeModel.RandomlyFilledTheLayer -= OnFillLayerRandom;
        }

        private void OnFillLayerRandom(Layer layer, int countTasks)
        {
            for (int i = 0; i < countTasks; i++)
            {
                int startTime;
                int endTime;
                
                if (layer.Tasks.Count == 0)
                {
                    startTime = UnityEngine.Random.Range(0, 300);
                }
                else
                {
                    int endTimeLastTask = layer.Tasks[layer.Tasks.Count - 1].EndTime;
                    startTime = UnityEngine.Random.Range(endTimeLastTask + 50, endTimeLastTask + 350);
                }

                endTime = UnityEngine.Random.Range(startTime + 100, startTime + 400);
                layer.AddTask(startTime, endTime);
            }
        }
    }
}