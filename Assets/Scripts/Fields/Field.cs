using UnityEngine;

namespace Fields
{
    public class Field : MonoBehaviour
    {
        public Potato PlantedPotato { get; private set; }
        public float CurrentGrowth { get; private set; }

        public Field(Potato potato)
        {
            PlantedPotato = potato;
            CurrentGrowth = 0f;
        }

        public void PlantPotato(Potato potato)
        {
            //Check if player can plant the potato here

            PlantedPotato = potato;
            CurrentGrowth = 0;
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
}