using System;
using System.Collections.Generic;
using Saving;

[Serializable]
public class SaveData
{
    public int Currency { get; internal set; }
    public QuestSaveData Quests { get; internal set; }
    public List<FieldSaveData> Fields { get; internal set; }
    public List<BuildingSaveData> BuildingData { get; internal set; }
    public List<WorkerSaveData> Workers { get; internal set; }
    public string CurrentSeason { get; internal set; }
}