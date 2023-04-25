using System.Collections.Generic;
using System.Linq;
using Managers;
using Saving;
using UnityEngine;

namespace Buildings
{
    public class BuildingManager
    {
        public int OverallWorkerLimit => _plots.Sum(x => x.BuildingData.Stats.WorkerCapacity);

        private readonly List<BuildingPlot> _plots;
        private readonly List<Building> _buildings;

        public BuildingManager(List<BuildingPlot> plots)
        {
            _plots = plots;
            _buildings = Resources.LoadAll<Building>("").ToList();
        }

        public Building GetBuilding(string buildingName) => _buildings.FindLast(x => x.BuildingName == buildingName);
        public BuildingPlot GetBuildingPlot(ushort id) => _plots.FindLast(x => x.Id == id);
        
        // Upgrade a specific building
        public void UpgradeBuilding(BuildingPlot plot)
        {
            // Implement upgrade logic
            Building building = plot.BuildingData.Building;
            int currentLevel = plot.BuildingData.Level;

            if (currentLevel < building.Levels.Count)
            {
                BuildingUpgrade upgrade = building.Levels[currentLevel];
                
                if (!GameManager.CurrencyManager.SpendCurrency(upgrade.Cost))
                    return;

                plot.BuildingData.LevelUp();

                // Update UI and save progress
                // ...
            }
            else
            {
                Debug.Log("Building already max level");
                // The building is already at the maximum level
                // ...
            }
        }
    
        public bool PurchaseBuilding(Building building, BuildingPlot plot)
        {
            if (!plot.CanPlaceBuilding(building))
                return false;

            if (!GameManager.CurrencyManager.SpendCurrency(building.Levels[0].Cost))
                return false;

            // Place the building on the plot
            plot.PlaceBuilding(building);

            // Update the UI
            // ...

            return true;
        }

        public bool DestroyBuilding(BuildingPlot plot)
        {
            if (!plot.IsOccupied) 
                return false;
            
            plot.RemoveBuilding();

            // Update the UI
            // ...
            
            return true;
        }

        public List<BuildingSaveData> GetSaveData() => _plots.Select(plot => new BuildingSaveData(plot)).ToList();

        public void LoadData(List<BuildingSaveData> buildingDataList)
        {
            foreach (BuildingSaveData data in buildingDataList)
            {
                BuildingPlot plot = GetBuildingPlot(data.Id);
                if (plot == null)
                {
                    Debug.Log("Plot not found");
                    return;
                }
                
                plot.PlaceBuilding(GetBuilding(data.BuildingName));
                plot.SetLevel(data.Level);
            }
        }

    }
}