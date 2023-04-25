using Buildings;
using TMPro;
using UnityEditor.Build.Reporting;
using UnityEngine;

[System.Serializable]
public class BuildingUpgrade
{
    [SerializeField] private int _cost;
    public int Cost => _cost;

    [SerializeField] private BuildingStats _stats;
    public BuildingStats Stats => _stats;
}