using Enums;
using Quests;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Potato Tycoon/Quest", order = 0)]
public class Quest : ScriptableObject
{
    [SerializeField] private string _questName;
    public string QuestName => _questName;

    [SerializeField] private string _description;
    public string Description => _description;

    
    //Quest values
    [SerializeField] private QuestType _questType;
    public QuestType QuestType => _questType;

    [SerializeField] private int _valueNeeded;
    public int ValueNeeded => _valueNeeded;

    //Reward
    [SerializeField] private int _currencyReward;
    public int CurrencyReward => _currencyReward;

    [SerializeField] private int _expReward;
    public int ExpReward => _expReward;
}