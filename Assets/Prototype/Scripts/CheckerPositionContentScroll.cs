using System;
using UnityEngine;

namespace Prototype.Scripts
{
    public class CheckerPositionContentScroll
    {
        private RectTransform _contentRect;
        private float _currentPositionContent;
        public event Action PositionChanged;

        public CheckerPositionContentScroll(RectTransform contentRect)
        {
            _contentRect = contentRect;
            _currentPositionContent = contentRect.anchoredPosition.y;
        }

        public void UpdateScroll()
        {
            if (Mathf.Abs(_currentPositionContent - _contentRect.anchoredPosition.y) > 100)
            {
                PositionChanged?.Invoke();
                _currentPositionContent = _contentRect.anchoredPosition.y - _contentRect.anchoredPosition.y % 100;
            }
        }
    }
}