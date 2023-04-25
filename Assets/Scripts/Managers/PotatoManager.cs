using System.Collections.Generic;
using Managers;
using Seasons;
using UnityEngine;

public class PotatoManager
{
    public List<Potato> Potatoes { get; private set; }

    [SerializeField] private float _defaultGrowthRate = 1.0f;
    
    private SeasonManager _season;
    private float _growthRate;

    public PotatoManager(float growthRate, List<Potato> potatoes)
    {
        _growthRate = growthRate;
        Potatoes = potatoes;
    }

    // Grow the selected potato species based on the current season and worker efficiency
    public void GrowPotato(Field field, float workerEfficiency)
    {
        Potato potato = field.PlantedPotato;
        float seasonalGrowthRate = GetSeasonalGrowthRate(potato, GameManager.Instance.SeasonManager.CurrentSeason);
        float growthAmount = _growthRate * seasonalGrowthRate * workerEfficiency;

        field.GrowPotato(growthAmount);

        // Implement additional logic, such as updating the UI or saving progress
        // ...
    }

    // Calculate the seasonal growth rate for a potato species
    private float GetSeasonalGrowthRate(Potato potato)
    {
        if (season >= 0 && season < potato.GrowthValuesPerSeason.Length)
        {
            return potato.GrowthValuesPerSeason[season];
        }
        return 1.0f; // Default growth value in case the season index is out of range
    }
    
    public Potato GetPotato(string potatoName)
    {
        foreach (Potato potato in Potatoes)
        {
            if (potato.PotatoName == potatoName)
            {
                return potato;
            }
        }

        return null;
    }
}