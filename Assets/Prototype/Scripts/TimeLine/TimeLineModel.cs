using System;
using UnityEngine;

namespace Prototype.Scripts.TimeLine
{
    public class TimeLineModel
    {
        public float CurrentPositinX = 0;
        public Vector2 InitialSize;
        public event Action SetedRandomPosition;

        public void SetRandomPosition()
        {
            SetedRandomPosition?.Invoke();
        }
    }
}