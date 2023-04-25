using Managers;
using UnityEngine;

namespace Saving
{
    public static class SaveLoadManager
    {
        private const string SaveKey = "potato_tycoon_save";

        public static void SaveGame(SaveData saveData)
        {
            SaveData data = new SaveData
            {
                Currency = GameManager.CurrencyManager.Currency,
                Quests = GameManager.QuestManager.GetSaveData(),
                Fields = GameManager.FieldManager.GetSaveData(),
                BuildingData = GameManager.BuildingManager.GetSaveData(),
                Workers = GameManager.WorkerManager.GetSaveData(),
                CurrentSeason = GameManager.SeasonManager.GetCurrentSeasonName()
            };

            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(SaveKey, json);
            PlayerPrefs.Save();
        }

        public static void LoadGame()
        {
            if (!PlayerPrefs.HasKey(SaveKey)) return;

            string json = PlayerPrefs.GetString(SaveKey);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            GameManager.CurrencyManager.SetCurrency(data.Currency);
            GameManager.QuestManager.LoadData(data.Quests);
            GameManager.FieldManager.LoadData(data.Fields);
            GameManager.BuildingManager.LoadData(data.BuildingData);
            GameManager.WorkerManager.LoadData(data.Workers);
            GameManager.SeasonManager.SetCurrentSeason(data.CurrentSeason);
        }

        public static bool HasSavedGame()
        {
            return PlayerPrefs.HasKey(SaveKey);
        }

        public static void DeleteSavedGame()
        {
            PlayerPrefs.DeleteKey(SaveKey);
            PlayerPrefs.Save();
        }
    }
}