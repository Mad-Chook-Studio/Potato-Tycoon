using System.Collections.Generic;
using Managers;

namespace Fields
{
    public class FieldManager
    {
        public List<Field> Fields { get; }

        public FieldManager(List<Field> fields) => Fields = fields;
        
        public void GrowPotatoes()
        {
            foreach (Field field in Fields)
            {
                float efficiency = GameManager.CalculateTotalEfficiency(field.PlantedPotato.Level);
                field.GrowPotato(GameManager.BaseGrowthRate * efficiency);
            }
        }
    }
}