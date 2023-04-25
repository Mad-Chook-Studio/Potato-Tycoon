using Workers;

namespace Saving
{
    public class WorkerSaveData
    {
        public string WorkerName { get; private set; }
        public int Level { get; private set; }
        public int Count { get; private set; }

        public WorkerSaveData(WorkerData data)
        {
            WorkerName = data.Worker.WorkerName;
            Level = data.GetLevel(false);
            Count = data.Count;
        }
    }
}