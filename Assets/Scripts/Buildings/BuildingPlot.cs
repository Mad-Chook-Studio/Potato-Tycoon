﻿using GameEnums;
using Generic;
using Saving;
using UnityEngine;

namespace Buildings
{
    public class BuildingPlot : WorldObject
    {
        [field: SerializeField]
        public BuildingSize Size { get; private set; }
    
        public bool IsOccupied { get; private set; }
        
        public BuildingData BuildingData { get; private set; }

        public void PlaceBuilding(Building building)
        {
            IsOccupied = true;
            BuildingData = new BuildingData(building);

            //Instantiate building
        }

        public void RemoveBuilding()
        {
            IsOccupied = false;
        
            //Remove building
        }

        public bool CanPlaceBuilding(Building building) => building.Size <= Size && !IsOccupied;

        public void SetLevel(int dataLevel)
        {
            while(BuildingData.Level < dataLevel)
                BuildingData.LevelUp();
        }
    }
}