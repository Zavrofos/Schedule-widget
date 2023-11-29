namespace Prototype.Scripts.Layers.Tasks
{
    public class Task
    {
        public readonly int StartTime;
        public readonly int EndTime;

        public Task(int startTime, int endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}