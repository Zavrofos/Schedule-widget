using Prototype.Scripts.Layers;
using Prototype.Scripts.Layers.Tasks;
using UnityEngine;

namespace Prototype.Scripts
{
    public class View : MonoBehaviour
    {
        public RectTransform ScrollContent;
        public LayerWindow LayerWindowPrefab;
        public TaskWindow TaskWindowPrefab;
        public int InitialCountLayers;
        public int CountLayerPool;
        public int CountTaskPool;
    }
}