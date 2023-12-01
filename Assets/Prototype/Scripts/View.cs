using Prototype.Scripts.Layers;
using Prototype.Scripts.Layers.Tasks;
using Prototype.Scripts.TimeScaleDir;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Scripts
{
    public class View : MonoBehaviour
    {
        public RectTransform ScrollContent;
        public RectTransform TimeScaleContent;
        public RectTransform TimeLineContent;

        public LayerWindow LayerWindowPrefab;
        public TaskWindow TaskWindowPrefab;
        public PartOfTimeScale PartOfTimeScalePrefab;
        public RectTransform TimeLine;
        
        public int InitialCountLayers;
        public int CountLayerPool;
        public int CountTaskPool;
    }
}