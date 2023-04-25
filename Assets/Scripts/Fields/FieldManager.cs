using System.Collections.Generic;
using Managers;

namespace Fields
{
    public class FieldManager
    {
        private List<Field> _fields;
        public List<Field> Fields => _fields;

        public FieldManager(List<Field> fields) => _fields = fields;
        
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