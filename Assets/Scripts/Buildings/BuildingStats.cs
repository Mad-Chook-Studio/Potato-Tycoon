using System.Net.Sockets;
using UnityEngine;

namespace Buildings
{
    [System.Serializable]
    public struct BuildingStats
    {
        [SerializeField] private float _multiplier;
        public float Multiplier => _multiplier;

        [SerializeField] private float _workerEfficiency;
        public float WorkerEfficiency => _workerEfficiency;

        [SerializeField] private int _workerCapacity;
        public int WorkerCapacity => _workerCapacity;

        public static BuildingStats operator +(BuildingStats stats1, BuildingStats stats2)
        {
            stats1._multiplier += stats2.Multiplier;
            stats1._workerEfficiency += stats2.WorkerEfficiency;
            stats1._workerCapacity += stats2.WorkerCapacity;

            return stats1;
        }
    }
}