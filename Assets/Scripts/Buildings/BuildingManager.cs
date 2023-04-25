using System.Collections.Generic;
using System.Linq;
using Managers;

namespace Buildings
{
    public class BuildingManager
    {
        public int OverallWorkerLimit => _plots.Sum(x => x.BuildingData.WorkerLimit);

        private readonly List<BuildingPlot> _plots;

        public BuildingManager(List<BuildingPlot> plots) => _plots = plots;

        // Upgrade a specific building
        public void UpgradeBuilding(BuildingPlot plot)
        {
            // Implement upgrade logic
            Building building = plot.BuildingData.Building;
            int currentLevel = plot.BuildingData.Level;

            if (currentLevel < building.Upgrades.Count)
            {
                BuildingUpgrade upgrade = building.Upgrades[currentLevel];
                
                if (!GameManager.Instance.CurrencyManager.SpendCurrency(upgrade.Cost))
                    return;

                plot.BuildingData.Level++;
                plot.BuildingData.WorkerLimit += upgrade.WorkerCapacity;

                // Update UI and save progress
                // ...
            }
            else
            {
                // The building is already at the maximum level
                // ...
            }
        }
    
        public bool PurchaseBuilding(Building building, BuildingPlot plot)
        {
            if (!plot.CanPlaceBuilding(building))
                return false;

            if (!GameManager.Instance.CurrencyManager.SpendCurrency(building.Upgrades[0].Cost))
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
    }
}