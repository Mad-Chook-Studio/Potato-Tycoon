using Fields;
using Potatoes;

namespace Saving
{
    public class FieldSaveData
    {
        public ushort Id { get; private set; }
        public string PlantedPotato { get; private set; }
        public float CurrentGrowth { get; private set; }

        public FieldSaveData(Field field)
        {
            Id = field.Id;
            PlantedPotato = field.PlantedPotato.PotatoName;
            CurrentGrowth = field.CurrentGrowth;
        }
    }
}