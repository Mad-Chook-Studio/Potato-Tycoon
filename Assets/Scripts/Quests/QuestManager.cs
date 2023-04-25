using System.Collections.Generic;
using System.Linq;
using GameEnums;
using Managers;
using Saving;
using UnityEngine;

namespace Quests
{
    public class QuestManager
    {
        private List<Quest> _quests;
        private readonly List<QuestData> _activeQuests = new();
        private readonly List<Quest> _completedQuests = new();

        public QuestManager() => _quests = Resources.LoadAll<Quest>("").ToList();

        // Start a quest
        public void StartQuest(Quest quest)
        {
            //If this quest is already in active
            if (!QuestIsActive(quest, out QuestData _))
            {
                Debug.Log("Quest has already started!");
                return;
            }
        
            _activeQuests.Add(new QuestData(quest));
            Debug.Log($"Started quest: {quest.QuestName}");
        }

        private bool QuestIsActive(Quest quest, out QuestData data)
        {
            data = _activeQuests.Find(x => x.Quest == quest);
            return data == null;
        }

        // Complete a quest
        public void CompleteQuest(Quest quest)
        {
            if(_completedQuests.Contains(quest))
            {
                Debug.Log("Quest already completed");
                return;
            }
        
            if (!QuestIsActive(quest, out QuestData data))
                return;

            if (data.Progress < data.Quest.ValueNeeded) return;
        
            _activeQuests.Remove(data);
            _completedQuests.Add(quest);
        
            GameManager.CurrencyManager.EarnCurrency(quest.CurrencyReward);
        }

        // Update quest progress based on the quest type
        public void UpdateQuestProgress(QuestType questType, int amount)
        {
            foreach (QuestData quest in _activeQuests.Where(quest => quest.Quest.QuestType == questType))
            {
                quest.UpdateQuestProgress(amount);
            }
        }

        public QuestSaveData GetSaveData() => new QuestSaveData(_completedQuests);

        public void LoadData(QuestSaveData data)
        {
            foreach (Quest quest in data.CompletedQuests.Select(FindQuestByName))
            {
                _completedQuests.Add(quest);
            }
        }

        private Quest FindQuestByName(string questName) => _quests.FindLast(x => x.QuestName == questName);
    }
}