using System;
using System.Collections.Generic;
using Prototype.Scripts.Layers;
using Prototype.Scripts.Layers.Tasks;
using Prototype.Scripts.TimeLine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Prototype.Scripts
{
    public class Starter : MonoBehaviour
    {
        public Model Model;
        public View View;

        public List<IPresenter> Presenters;
        public List<IUpdater> Updaters;
        
        private void Awake()
        {
            Model = new Model();

            Presenters = new List<IPresenter>()
            {
                new InitializeModelPresenter(Model, View),
                new AddingLayerPresenter(Model, View),
                new RedrawLayersPresenter(Model, View),
                new InitializeTasksPresenter(Model, View),
                new RedrawTasksPresenter(Model, View),
                new InitializeTimeLinePresenter(Model, View)
            };

            Updaters = new List<IUpdater>()
            {
                new CheckPositionContentScrollUpdater(Model, View)
            };
        }

        private void Start()
        {
            Model.Initialize();
        }

        private void Update()
        {
            foreach (var updater in Updaters)
            {
                updater.Update(Time.deltaTime);
            }
        }
        
        private void OnEnable()
        {
            foreach (var presenter in Presenters)
            {
                presenter.Subscribe();
            }
        }

        private void OnDisable()
        {
            foreach (var presenter in Presenters)
            {
                presenter.Unsubscribe();
            }
        }
    }
}
