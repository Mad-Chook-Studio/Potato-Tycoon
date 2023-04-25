using System;
using UnityEngine;

namespace Workers
{
    [Serializable]
    public class WorkerUpgrade
    {
        [SerializeField] private int _upgradeCost;
        public int UpgradeCost => _upgradeCost;
        
        [SerializeField] private float _upgradeEfficiency;
        public float UpgradeEfficiency => _upgradeEfficiency;
    }
}