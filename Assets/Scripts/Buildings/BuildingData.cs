namespace Buildings
{
    [System.Serializable]
    public class BuildingData
    {
        public Building Building;
        public int Level;
        public int WorkerLimit;
        public int WorkersAssigned;

        public BuildingData(Building building, int level = 0, int workersAssigned = 0)
        {
            Building = building;
            Level = level;
            WorkersAssigned = workersAssigned;
        }
    }
}