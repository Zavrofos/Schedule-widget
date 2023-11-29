using System;

namespace Prototype.Scripts
{
    public class Layer
    {
        public readonly int InitialPosition;
        public bool IsActive;
        public LayerWindow LayerWindow;
        public event Action<Layer> TurnedOn;
        public event Action<Layer> TurnedOff;

        public Layer(int initialPosition)
        {
            InitialPosition = initialPosition;
            IsActive = false;
        }

        public void TurnOn()
        {
            IsActive = true;
            TurnedOn?.Invoke(this);
        }

        public void TurnOff()
        {
            IsActive = false;
            TurnedOff?.Invoke(this);
        }
    }
}