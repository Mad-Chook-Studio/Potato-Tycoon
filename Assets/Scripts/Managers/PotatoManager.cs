using System.Collections.Generic;
using System.Linq;
using Fields;
using Managers;
using Seasons;
using UnityEngine;

public class PotatoManager
{
    public List<Potato> Potatoes { get; private set; }
    
    private SeasonManager _season;

    public PotatoManager() => Potatoes = Resources.LoadAll<Potato>("").ToList();

    // Grow the selected potato species based on the current season and worker efficiency
    public void GrowPotato(Field field, float workerEfficiency)
    {
        Potato potato = field.PlantedPotato;
        float seasonalGrowthRate = GameManager.SeasonManager.GetSeasonalGrowthRate(potato);
        float growthAmount = GameManager.BaseGrowthRate * seasonalGrowthRate * workerEfficiency;

        field.GrowPotato(growthAmount);

        // Implement additional logic, such as updating the UI or saving progress
        // ...
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