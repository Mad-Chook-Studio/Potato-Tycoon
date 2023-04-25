using System.Collections.Generic;
using GameEnums;
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

        [SerializeField] private List<BuildingUpgrade> _levels;
        public List<BuildingUpgrade> Levels => _levels;

        [SerializeField] private BuildingSize _size;
        public BuildingSize Size => _size;
    }
}