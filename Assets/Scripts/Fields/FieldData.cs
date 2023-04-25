using System;

namespace Fields
{
    [Serializable]
    public class FieldData
    {
        public string PotatoName { get; private set; }
        public float GrowthProgress { get; private set; }

        public FieldData(Field field)
        {
            PotatoName = field.PlantedPotato.PotatoName;
            GrowthProgress = field.CurrentGrowth;
        }
    }
}