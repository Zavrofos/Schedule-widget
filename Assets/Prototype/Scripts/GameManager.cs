using System;
using System.Collections.Generic;
using Prototype.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Prototipe.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public RectTransform ConteinerScroll;
        public int InitialCountLayers;
        public int CountLayerPool;
        public Pool<LayerWindow> PoolLayerWindows;
        [FormerlySerializedAs("LayerExampleWindowPrefab")] public LayerWindow layerWindowPrefab;
        

        private List<Layer> _layers;
        private CheckerPositionContentScroll CheckerPosition;

        private void Start()
        {
            PoolLayerWindows =
                new Pool<LayerWindow>(layerWindowPrefab, ConteinerScroll, CountLayerPool);

            _layers = new List<Layer>();

            float newHeight = InitialCountLayers * 100;
            ConteinerScroll.sizeDelta = new Vector2(ConteinerScroll.sizeDelta.x, newHeight);

            int position = 0;
            for (int i = 0; i < InitialCountLayers; i++)
            {
                var layerExample = new Layer(position);
                layerExample.TurnedOn += TurnOnLayer;
                layerExample.TurnedOff += TurnOffLayer;
                _layers.Add(layerExample);
                position += 100;
            }

            CheckerPosition = new CheckerPositionContentScroll(ConteinerScroll);
            CheckerPosition.PositionChanged += RedrawLayers;
            RedrawLayers();
        }

        private void Update()
        {
            CheckerPosition.UpdateScroll();
        }

        private void RedrawLayers()
        {
            foreach (var layer in _layers)
            {
                if ((layer.InitialPosition + 200 + 100) > ConteinerScroll.anchoredPosition.y &&
                    (ConteinerScroll.anchoredPosition.y + 1000) > layer.InitialPosition)
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

        private void TurnOnLayer(Layer layer)
        {
            LayerWindow layerWindow = PoolLayerWindows.GetFreeElement();
            var anchoredPosition = layerWindow.RectTransform.anchoredPosition;
            anchoredPosition = new Vector3(0, -layer.InitialPosition, 0);
            layerWindow.RectTransform.anchoredPosition = anchoredPosition;
            layer.LayerWindow = layerWindow;
        }

        private void TurnOffLayer(Layer layer)
        {
            layer.LayerWindow.RectTransform.anchoredPosition = Vector3.zero;
            // layer.LayerExampleWindow.gameObject.SetActive(false);
            layer.LayerWindow = null;
        }

        private void OnDisable()
        {
            foreach (var layer in _layers)
            {
                layer.TurnedOn -= TurnOnLayer;
                layer.TurnedOff -= TurnOffLayer;
            }
            CheckerPosition.PositionChanged -= RedrawLayers;
        }
    }
}
