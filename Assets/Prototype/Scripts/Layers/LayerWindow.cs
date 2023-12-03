using System;
using Prototype.Scripts.Tasks;
using UnityEngine;

namespace Prototype.Scripts.Layers
{
    public class LayerWindow : MonoBehaviour
    {
        public RectTransform RectTransform;
        public Pool<TaskWindow> PoolTaskWindows;
    }
}