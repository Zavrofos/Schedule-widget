using System;

namespace Prototype.Scripts.TimeScaleDir
{
    public class PartOfTimeScale
    {
        public float Position;

        public event Action TurnedOn;
        public event Action TurnedOff;
        public bool IsActive = false;

        public PartOfTimeScale(float position)
        {
            Position = position;
        }

        public void TurnOn()
        {
            TurnedOn?.Invoke();
        }

        public void TurnOff()
        {
            TurnedOff?.Invoke();
        }
    }
}