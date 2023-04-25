using System.Collections.Generic;
using Managers;
using System.Linq;

namespace Workers
{
    public class WorkerManager
    {
        public List<WorkerData> Workers { get; private set; }

        // Hire a worker
        public bool HireWorker(Worker workerToHire)
        {
            if (!GameManager.Instance.CurrencyManager.SpendCurrency(workerToHire.Cost))
                return false;

            if (GetWorkerCount() >= GameManager.Instance.BuildingManager.OverallWorkerLimit)
                return false;

            if (!GetWorker(workerToHire, out WorkerData data))
            {
                data.AddWorker();
            }
            else
            {
                Workers.Add(new WorkerData(workerToHire));
            }
            
            return true; // Worker successfully hired
        }

        public bool FireWorker(Worker workerToFire)
        {
            if (!GetWorker(workerToFire, out WorkerData data))
                return false;
            
            data.RemoveWorker();
            if (data.Count <= 0)
                Workers.RemoveAll(x => x.Worker == workerToFire);
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
            if (!GameManager.Instance.CurrencyManager.SpendCurrency(upgrade.UpgradeCost))
                return false;
            
            data.LevelUp();
            return true;
        }
        
        public int GetWorkerCount() => Workers.Sum(x => x.Count);

        private bool GetWorker(Worker worker, out WorkerData data)
        {
            data = Workers.Find(x => x.Worker == worker);
            return data != null;
        }
    }
}