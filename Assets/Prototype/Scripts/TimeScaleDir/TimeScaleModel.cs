using System;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Scripts.TimeScaleDir
{
    public class TimeScaleModel
    {
        public int LastValueTime = 0;
        public Vector2 InitialSize;
        public List<PartOfTimeScale> PartsOfTimeScale;
        
        public event Action Initialized;
        public event Action AddedpartOfTimeScale;

        public TimeScaleModel()
        {
            PartsOfTimeScale = new List<PartOfTimeScale>();
        }
        
        public void Initialize()
        {
            Initialized?.Invoke();
        }

        public void AddPartOfTimeScale()
        {
            AddedpartOfTimeScale?.Invoke();
        }
    }
}