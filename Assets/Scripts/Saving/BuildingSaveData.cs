using Buildings;

namespace Saving
{
    public class BuildingSaveData
    {
        public ushort Id { get; private set; }
        public string BuildingName { get; private set; }
        public int Level { get; private set; }

        public BuildingSaveData(ushort id, string buildingName, int level)
        {
            BuildingName = buildingName;
            Level = level;
        }

        public BuildingSaveData(BuildingPlot plot)
        {
            Id = plot.Id;
            BuildingName = plot.BuildingData.Building.BuildingName;
            Level = plot.BuildingData.Level;
        }
    }
}