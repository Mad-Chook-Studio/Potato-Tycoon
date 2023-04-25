using System.Collections.Generic;
using System.Linq;
using Managers;
using Potatoes;
using Saving;
using UnityEngine;

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
        
        public List<FieldData> GetFieldData() => _fields.Select(field => new FieldData(field)).ToList();

        public void SetFieldData(List<FieldData> fieldDataList)
        {
            for (int i = 0; i < fieldDataList.Count; i++)
            {
                _fields[i].SetFieldData(fieldDataList[i]);
            }
        }

        public Field GetField(ushort id) => _fields.FindLast(x => x.Id == id);

        public List<FieldSaveData> GetSaveData()
        {
            List<FieldSaveData> data = new();

            foreach (Field field in _fields)
            {
                data.Add(new FieldSaveData(field));
            }

            return data;
        }

        public void LoadData(List<FieldSaveData> fieldSaveData)
        {
            foreach (FieldSaveData data in fieldSaveData)
            {
                Field field = GetField(data.Id);
                Potato potato = GameManager.PotatoManager.GetPotato(data.PlantedPotato);
                
                if (field == null)
                {
                    Debug.Log("Field not found");
                    return;
                }
                
                field.PlantPotato(potato);
                field.SetGrowth(data.CurrentGrowth);
            }
        }
    }
}