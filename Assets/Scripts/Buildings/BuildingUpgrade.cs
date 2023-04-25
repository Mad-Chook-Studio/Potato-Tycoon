using UnityEngine;

[System.Serializable]
public class BuildingUpgrade
{
    [SerializeField] private int _cost;
    public int Cost => _cost;

    [SerializeField] private float _potatoMultiplier;
    public float PotatoMultiplier => _potatoMultiplier;

    [SerializeField] private float _workerEfficiency;
    public float WorkerEfficiency => _workerEfficiency;

    [SerializeField] private int _workerCapacity;
    public int WorkerCapacity => _workerCapacity;
}