using System.Collections.Generic;
using Prototype.Scripts.avl_tree_c_sharp_master.Bitlush.AvlTree;
using Prototype.Scripts.Tasks;

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
            float positionY = _view.WorkZoneScrollContent.anchoredPosition.y;
            float upBoard = positionY - 300;
            float downBoard = positionY + 1000;

            var toRemove = new HashSet<Layer>(_model.LayersModel.IncludedLayers.Keys);
            List<Layer> layerToTurnOn = _model.LayersModel.Layers.GetValuesBetweenBoundaries(upBoard, downBoard);

            foreach (var layer in layerToTurnOn)
            {
                if (layer.IsActive)
                {
                    toRemove.Remove(layer);
                }
                else
                {
                    layer.TurnOn();
                }
            }

            foreach (var layer in toRemove)
            {
                layer.TurnOff();
            }
            
            _model.VirtualizationModel.ChangeContentScrollPositionHorizontal();
        }
    }
}