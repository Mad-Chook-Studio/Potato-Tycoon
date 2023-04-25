using Unity.VisualScripting;

namespace Workers
{
    public class WorkerData
    {
        public Worker Worker { get; private set; }
        public int Level => Worker.WorkerLevel + _currentLevel;
        public float EfficiencyMultiplier { get; private set; }
        public int Count { get; private set; }

        private int _currentLevel;

        public WorkerData(Worker worker)
        {
            Worker = worker;
            _currentLevel = 0;
            Count = 1;
            EfficiencyMultiplier = Worker.EfficiencyMultiplier;
        }

        public void AddWorker() => Count++;
        public void RemoveWorker() => Count--;

        public void LevelUp()
        {
            EfficiencyMultiplier += Worker.Upgrades[Level].UpgradeCost;
            _currentLevel++;
        }

        public bool CanBeUpgraded() => _currentLevel < Worker.Upgrades.Length;

        public WorkerUpgrade GetNextUpgrade() => !CanBeUpgraded() ? null : Worker.Upgrades[_currentLevel];
    }
}