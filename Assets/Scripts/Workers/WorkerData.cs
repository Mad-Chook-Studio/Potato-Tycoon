namespace Workers
{
    public class WorkerData
    {
        public Worker Worker { get; }
        public float EfficiencyMultiplier { get; private set; }
        public int Count { get; private set; }
        
        private int _currentLevel;

        public WorkerData(Worker worker)
        {
            Worker = worker;
            _currentLevel = 1;
            Count = 1;
            EfficiencyMultiplier = Worker.Levels[0].UpgradeEfficiency;
        }

        public void AddWorker() => Count++;
        public void RemoveWorker() => Count--;

        public void LevelUp()
        {
            EfficiencyMultiplier += Worker.Levels[GetLevel()].Cost;
            _currentLevel++;
        }

        public int GetLevel(bool includeDefault = true) =>
            includeDefault ? Worker.WorkerLevel + _currentLevel : _currentLevel;

        public bool CanBeUpgraded() => _currentLevel < Worker.Levels.Length;

        public WorkerUpgrade GetNextUpgrade() => !CanBeUpgraded() ? null : Worker.Levels[_currentLevel];
    }
}