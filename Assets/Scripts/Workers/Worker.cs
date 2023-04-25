using UnityEngine;

namespace Workers
{
    [CreateAssetMenu(fileName = "NewWorker", menuName = "Potato Tycoon/Worker", order = 0)]
    public class Worker : ScriptableObject
    {
        [SerializeField] private string _workerName;
        public string WorkerName => _workerName;

        [SerializeField] private int _workerLevel;
        public int WorkerLevel => _workerLevel;

        [SerializeField] private WorkerUpgrade[] _levels;
        public WorkerUpgrade[] Levels => _levels;

        [SerializeField] private uint[] _additionalWorkerCost;
        private uint[] AdditionalWorkerCost => _additionalWorkerCost;
    }
}
