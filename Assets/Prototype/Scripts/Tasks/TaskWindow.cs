using System;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Scripts.Tasks
{
    public class TaskWindow : MonoBehaviour
    {
        public RectTransform TaskRectTransform;
        public Image Image;
        
        private Vector2 _initialSize;
        public Vector2 InitialSize => _initialSize;

        private void Awake()
        {
            _initialSize = TaskRectTransform.sizeDelta;
        }
    }
}