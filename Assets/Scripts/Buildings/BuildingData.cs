namespace Buildings
{
    [System.Serializable]
    public class BuildingData
    {
        public Building Building { get; private set; }
        public int Level { get; private set; }
        public BuildingStats Stats { get; private set; }
        public int WorkersAssigned { get; private set; }

        public BuildingData(Building building, int level = 1, int workersAssigned = 0)
        {
            Building = building;
            Level = level;
            Stats = building.Levels[0].Stats;
            WorkersAssigned = workersAssigned;
        }

        public void LevelUp()
        {
            if (Level >= Building.Levels.Count) return;
            Stats += Building.Levels[Level].Stats;
            Level++;
        }
    }
}