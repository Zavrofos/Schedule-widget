using System;
using UnityEngine;

namespace Prototype.Scripts.WorkZone
{
    public class WorkZoneModel
    {
        public float contentSizeX = 0;
        public float contentSizeY = 0;

        public Vector2 InitialSize;

        public int UpBorderMargin { get; } = 300;
        public int DownBorderMargin { get; } = 1000;
        public int LeftBorderMargin { get; } = 200;
        public int RightBordermargin { get; } = 1800;
        
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