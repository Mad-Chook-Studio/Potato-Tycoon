using UnityEngine;

public class Field : MonoBehaviour
{
    public Potato PlantedPotato { get; set; }
    public float CurrentGrowth { get; set; }

    public Field(Potato potato)
    {
        PlantedPotato = potato;
        CurrentGrowth = 0f;
    }

    public void GrowPotato(float growthRate)
    {
        if (PlantedPotato == null) return;
        
        CurrentGrowth += growthRate;

        if (CurrentGrowth > PlantedPotato.MaxGrowth)
        {
            CurrentGrowth = PlantedPotato.MaxGrowth;
        }
    }
}