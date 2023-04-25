using System.Collections.Generic;
using Managers;
using System.Linq;

namespace Workers
{
    public class WorkerManager
    {
        private readonly List<WorkerData> _workers = new();

        // Hire a worker
        public bool HireWorker(Worker workerToHire)
        {
            if (!GameManager.CurrencyManager.SpendCurrency(workerToHire.Levels[0].Cost))
                return false;

            if (GetWorkerCount() >= GameManager.BuildingManager.OverallWorkerLimit)
                return false;

            if (!GetWorker(workerToHire, out WorkerData data))
            {
                data.AddWorker();
            }
            else
            {
                _workers.Add(new WorkerData(workerToHire));
            }
            
            return true; // Worker successfully hired
        }

        public bool FireWorker(Worker workerToFire)
        {
            if (!GetWorker(workerToFire, out WorkerData data))
                return false;
            
            data.RemoveWorker();
            if (data.Count <= 0)
                _workers.RemoveAll(x => x.Worker == workerToFire);
            return true;
        }

        public bool UpgradeWorker(Worker workerToUpgrade)
        {
            if (!GetWorker(workerToUpgrade, out WorkerData data))
                return false;

            WorkerUpgrade upgrade = data.GetNextUpgrade();

            //Are there more upgrades??
            if (upgrade == null)
                return false;

            //Can the player afford it?
            if (!GameManager.CurrencyManager.SpendCurrency(upgrade.Cost))
                return false;
            
            data.LevelUp();
            return true;
        }

        private int GetWorkerCount() => _workers.Sum(x => x.Count);

        private bool GetWorker(Worker worker, out WorkerData data)
        {
            data = _workers.Find(x => x.Worker == worker);
            return data != null;
        }

        public float GetWorkerEfficiency(int potatoLevel) => _workers.Where(worker => worker.Level >= potatoLevel)
            .Sum(worker => worker.EfficiencyMultiplier);
    }
}