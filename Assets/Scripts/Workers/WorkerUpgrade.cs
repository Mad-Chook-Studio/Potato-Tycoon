using System;
using UnityEngine;

namespace Workers
{
    [Serializable]
    public class WorkerUpgrade
    {
        [SerializeField] private int _cost;
        public int Cost => _cost;
        
        [SerializeField] private float _upgradeEfficiency;
        public float UpgradeEfficiency => _upgradeEfficiency;
    }
}