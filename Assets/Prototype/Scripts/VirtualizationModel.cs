using System;

namespace Prototype.Scripts
{
    public class VirtualizationModel
    {
        public event Action ContentScrollPositionChangedVertical;
        public event Action ContentScrollPositionChangedHorizontal;

        public void Initialize()
        {
            ChangeContentScrollPositionVertical();
            ChangeContentScrollPositionHorizontal();
        }
        
        public void ChangeContentScrollPositionVertical()
        {
            ContentScrollPositionChangedVertical?.Invoke();
        }
        
        public void ChangeContentScrollPositionHorizontal()
        {
            ContentScrollPositionChangedHorizontal?.Invoke();
        }
    }
}