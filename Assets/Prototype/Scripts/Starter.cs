using System;
using System.Collections.Generic;
using Prototype.Scripts.Layers;
using Prototype.Scripts.Random;
using Prototype.Scripts.Tasks;
using Prototype.Scripts.TimeLine;
using Prototype.Scripts.TimeScaleDir;
using Prototype.Scripts.WorkZone;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

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
                new SetRandomLayersPresenter(Model, View),
                new RedrawLayersPresenter(Model, View),
                new AddNewLayerButtonPresenter(Model, View),
                new RandomTaskFillerPresenter(Model, View),
                
                new SetContentWorkZoneSizePresenter(Model, View),
                new SetTimeLineContentSizePresenter(Model, View),
                new SetTimeScaleContentSizeXPresenter(Model, View),
                
                new InitializeTimeScalePresenter(Model, View),
                new AddingPartOfTimeScalePresenter(Model, View),
                
                new SettingRandomPositionTimeLinePresenter(Model, View),
                new GeneratePresenter(Model, View)
            };

            Updaters = new List<IUpdater>()
            {
                new CheckPositionContentScrollUpdater(Model, View)
            };
        }

        private void Start()
        {
            Model.Initialize();
            Model.TimeScaleModel.Initialize();
            Model.RandomizeModel.SetRandomLayers();
            Model.TimeLineModel.SetRandomPosition();
            Model.VirtualizationModel.ChangeContentScrollPositionVertical();
            Model.VirtualizationModel.ChangeContentScrollPositionHorizontal();
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
