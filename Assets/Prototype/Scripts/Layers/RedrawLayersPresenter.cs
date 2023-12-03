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
            List<Layer> layersToTurnOff = new List<Layer>();
            foreach (var layer in _model.LayersModel.IncludedLayers.Keys)
            {
                layersToTurnOff.Add(layer);
            }
            foreach (var layer in layersToTurnOff)
            {
                layer.TurnOff();
            }
            
            float positionY = _view.WorkZoneScrollContent.anchoredPosition.y;
            float upBoard = positionY - 300;
            float downBoard = positionY + 1000;
            
            int upBoardLayerPositionIndex = _model.LayersModel.GetUpBoardLayerPosition(upBoard);
            int downBoardLayerPositionIndex = _model.LayersModel.GetDownBoardLayerPosition(downBoard);

            for (int i = upBoardLayerPositionIndex; i <= downBoardLayerPositionIndex; i++)
            {
                _model.LayersModel.Layers[i].TurnOn();
            }
            
            _model.VirtualizationModel.ChangeContentScrollPositionHorizontal();
        }
    }
}