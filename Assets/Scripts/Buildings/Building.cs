using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Buildings
{
    [CreateAssetMenu(fileName = "NewBuilding", menuName = "Potato Tycoon/Building", order = 0)]
    public class Building : ScriptableObject
    {
        [SerializeField] private string _buildingName;
        public string BuildingName => _buildingName;

        [SerializeField] private Sprite _buildingSprite;
        public Sprite BuildingSprite => _buildingSprite;

        [SerializeField] private int _workerCapacity;
        public int WorkerCapacity => _workerCapacity;

        [SerializeField] private List<BuildingUpgrade> _upgrades;
        public List<BuildingUpgrade> Upgrades => _upgrades;

        [SerializeField] private BuildingSize _size;
        public BuildingSize Size => _size;
    }
}