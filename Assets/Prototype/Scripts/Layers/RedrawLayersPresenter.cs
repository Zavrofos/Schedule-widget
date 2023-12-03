using System.Collections.Generic;
using Prototype.Scripts.avl_tree_c_sharp_master.Bitlush.AvlTree;

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
            _model.VirtualizationModel.ContentScrollPositionChangedVertical += OnRedrawLayers;
        }

        public void Unsubscribe()
        {
            _model.VirtualizationModel.ContentScrollPositionChangedVertical -= OnRedrawLayers;
        }

        private void OnRedrawLayers()
        {
            // foreach (var layer in _model.LayersModel.Layers)
            // {
            //     if ((layer.InitialPosition + 200 + 100) > _view.WorkZoneScrollContent.anchoredPosition.y &&
            //         (_view.WorkZoneScrollContent.anchoredPosition.y + 1000) > layer.InitialPosition)
            //     {
            //         if (!layer.IsActive)
            //         {
            //             layer.TurnOn();
            //         }
            //     }
            //     else
            //     {
            //         if (layer.IsActive)
            //         {
            //             layer.TurnOff();
            //         }
            //     }
            // }

            // попытка

            List<Layer> layersToTurnOff = new List<Layer>();
            foreach (var layer in _model.LayersModel.IncludedLayers.Keys)
            {
                layersToTurnOff.Add(layer);
            }
            foreach (var layer in layersToTurnOff)
            {
                layer.TurnOff();
            }

            float downCount = 3;
            float upCount = 10;
            float currentPositionY = _view.WorkZoneScrollContent.anchoredPosition.y;
            float positionY = 100 - (currentPositionY % 100) + currentPositionY;

            float posYDown = positionY;
            for (int i = 0; i < downCount; i++)
            {
                Layer layer;
                if (_model.LayersModel.Layers.Search(posYDown, out layer))
                {
                    if (!layer.IsActive)
                    {
                        layer.TurnOn();
                    }
                }

                posYDown -= 100;
            }

            float posYUp = positionY;
            for (int i = 0; i < upCount; i++)
            {
                Layer layer;
                if (_model.LayersModel.Layers.Search(posYUp, out layer))
                {
                    if (!layer.IsActive)
                    {
                        layer.TurnOn();
                    }
                }

                posYUp += 100;
            }
            
            
            // попытка
            
            _model.VirtualizationModel.ChangeContentScrollPositionHorizontal();
        }
    }
}