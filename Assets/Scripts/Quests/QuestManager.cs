using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Managers;
using Quests;
using UnityEngine;

public class QuestManager
{
    [SerializeField] private List<Quest> _quests;
    private List<QuestData> _activeQuests = new();
    private List<Quest> _completedQuests = new();

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
        
        GameManager.Instance.CurrencyManager.EarnCurrency(quest.CurrencyReward);
    }

    // Update quest progress based on the quest type
    public void UpdateQuestProgress(QuestType questType, int amount)
    {
        foreach (QuestData quest in _activeQuests.Where(quest => quest.Quest.QuestType == questType))
        {
            quest.UpdateQuestProgress(amount);
        }
    }
}