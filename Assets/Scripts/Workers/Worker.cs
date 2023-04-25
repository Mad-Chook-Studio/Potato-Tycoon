using UnityEngine;
using Workers;

[CreateAssetMenu(fileName = "NewWorker", menuName = "Potato Tycoon/Worker", order = 0)]
public class Worker : ScriptableObject
{
    [SerializeField] private string _workerName;
    public string WorkerName => _workerName;

    [SerializeField] private int _cost;
    public int Cost => _cost;

    [SerializeField] private int _workerLevel;
    public int WorkerLevel => _workerLevel;

    [SerializeField] private float _efficiencyMultiplier;
    public float EfficiencyMultiplier => _efficiencyMultiplier;

    [SerializeField] private WorkerUpgrade[] _upgrades;
    public WorkerUpgrade[] Upgrades => _upgrades;
}
