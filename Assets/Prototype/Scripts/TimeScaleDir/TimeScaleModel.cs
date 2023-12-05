using System;
using System.Collections.Generic;
using Prototype.Scripts.Tree;
using UnityEngine;

namespace Prototype.Scripts.TimeScaleDir
{
    public class TimeScaleModel
    {
        public int LastValueTime = 0;
        public Vector2 InitialSize;
        
        public Pool<PartOfTimeScaleWindow> PartOfTimeScalePool;
        public BinaryTree<float, PartOfTimeScale> PartsOfTimeScale;
        public Dictionary<PartOfTimeScale, PartOfTimeScaleWindow> IncludedPartsOfTime;
        
        public event Action Initialized;
        public event Action AddedPartOfTimeScale;
        public event Action<PartOfTimeScale> RemovedPartOfTimeScale;
        
        public TimeScaleModel()
        {
            PartsOfTimeScale = new BinaryTree<float, PartOfTimeScale>();
            IncludedPartsOfTime = new Dictionary<PartOfTimeScale, PartOfTimeScaleWindow>();
        }
        
        public void Initialize()
        {
            Initialized?.Invoke();
        }

        public void AddPartOfTimeScale()
        {
            AddedPartOfTimeScale?.Invoke();
        }

        public void RemovePartOfTimeScale(PartOfTimeScale partOfTimeScale)
        {
            RemovedPartOfTimeScale?.Invoke(partOfTimeScale);
        }
    }
}