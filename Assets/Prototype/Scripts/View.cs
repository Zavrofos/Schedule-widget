using Prototype.Scripts.Layers;
using Prototype.Scripts.Tasks;
using Prototype.Scripts.TimeScaleDir;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Prototype.Scripts
{
    public class View : MonoBehaviour
    {
        public RectTransform WorkZoneScrollContent;
        public RectTransform TimeScaleContent;
        public RectTransform TimeLineContent;

        public LayerWindow LayerWindowPrefab;
        public TaskWindow TaskWindowPrefab;
        public PartOfTimeScale PartOfTimeScalePrefab;
        public RectTransform TimeLine;
        public Button GenerateButton;

        public Button AddNewLayerButton;
        public TMP_Text CountElementsInNewLayerText;

        public Color PendingColorTask;
        public Color CompletedColorTask;
        public Color JeopardyColorTask;

        public TMP_Text PendingCountText;
        public TMP_Text JeopardyCountText;
        public TMP_Text CompletedCountText;
        
        public int CountLayerPool;
        public int CountTaskPool;
        public int MaxTasksInLayer;
    }
}