using System.Collections.Generic;
using Managers;
using System.Linq;
using Saving;
using TMPro;
using UnityEngine;

namespace Workers
{
    public class WorkerManager
    {
        private readonly List<Worker> _workers = new();
        private readonly List<WorkerData> _workersData = new();

        public WorkerManager() => _workers = Resources.LoadAll<Worker>("").ToList();

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
                _workersData.Add(new WorkerData(workerToHire));
            }
            
            return true; // Worker successfully hired
        }

        public bool FireWorker(Worker workerToFire)
        {
            if (!GetWorker(workerToFire, out WorkerData data))
                return false;
            
            data.RemoveWorker();
            if (data.Count <= 0)
                _workersData.RemoveAll(x => x.Worker == workerToFire);
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

        private int GetWorkerCount() => _workersData.Sum(x => x.Count);

        private bool GetWorker(Worker worker, out WorkerData data)
        {
            data = _workersData.Find(x => x.Worker == worker);
            return data != null;
        }

        private Worker GetWorkerByName(string workerName) =>
            _workers.FindLast(x => x.WorkerName == workerName);

        public float GetWorkerEfficiency(int potatoLevel) => _workersData.Where(worker => worker.GetLevel() >= potatoLevel)
            .Sum(worker => worker.EfficiencyMultiplier);
        
        public List<WorkerSaveData> GetSaveData() => _workersData.Select(worker => new WorkerSaveData(worker)).ToList();

        public void LoadData(List<WorkerSaveData> workerSaveData)
        {
            foreach (WorkerSaveData data in workerSaveData)
            {
                Worker worker = GetWorkerByName(data.WorkerName);
                
                if (worker == null)
                {
                    Debug.Log("Worker not found");
                    return;
                }
                
                WorkerData workerData = new WorkerData(worker);
                while(workerData.GetLevel(false) < data.Level)
                    workerData.LevelUp();
                
                _workersData.Add(workerData);
            }
        }
    }
}