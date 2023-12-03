using System;
using UnityEngine;

namespace Prototype.Scripts.WorkZone
{
    public class WorkZoneModel
    {
        public float contentSizeX = 0;
        public float contentSizeY = 0;

        public Vector2 InitialSize;
        
        public event Action<float> ChangedContentSizeX;
        public event Action<float> ChangedContentSizeY;
        
        public void ChangeContentSizeX(float newSizeX)
        {
            ChangedContentSizeX?.Invoke(newSizeX);
        }

        public void ChangeContentSizeY(float newSizeY)
        {
            ChangedContentSizeY?.Invoke(newSizeY);
        }
    }
}