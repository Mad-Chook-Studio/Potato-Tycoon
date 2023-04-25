using System.Collections.Generic;
using Managers;

namespace Fields
{
    public class FieldManager
    {
        private readonly List<Field> _fields;

        public FieldManager(List<Field> fields) => _fields = fields;
        
        public void GrowPotatoes()
        {
            foreach (Field field in _fields)
            {
                float efficiency = GameManager.CalculateTotalEfficiency(field.PlantedPotato.Level);
                field.GrowPotato(GameManager.BaseGrowthRate * efficiency);
            }
        }
    }
}