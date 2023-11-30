﻿using UnityEngine;

namespace Prototype.Scripts.Layers
{
    public class TurningOnLayerPresenter : IPresenter
    {
        private readonly Model _model;
        private readonly Layer _layer;
        private readonly View _view;

        public TurningOnLayerPresenter(Model model, Layer layer, View view)
        {
            _model = model;
            _layer = layer;
            _view = view;
        }

        public void Subscribe()
        {
            _layer.TurnedOn += OnTurnOn;
        }

        public void Unsubscribe()
        {
            _layer.TurnedOn += OnTurnOn;
        }

        private void OnTurnOn(Layer layer)
        {
            LayerWindow layerWindow = _model.PoolLayerWindows.GetFreeElement();
            var anchoredPosition = layerWindow.RectTransform.anchoredPosition;
            anchoredPosition = new Vector3(0, -layer.InitialPosition, 0);
            layerWindow.RectTransform.anchoredPosition = anchoredPosition;
            layer.LayerWindow = layerWindow;
        }
    }
}