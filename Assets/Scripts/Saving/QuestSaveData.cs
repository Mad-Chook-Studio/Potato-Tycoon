using System.Collections.Generic;
using Quests;

namespace Saving
{
    public class QuestSaveData
    {
        public List<string> CompletedQuests { get; private set; }

        public QuestSaveData(List<Quest> completedQuests)
        {
            CompletedQuests = new List<string>();
            
            foreach (Quest quest in completedQuests)
            {
                CompletedQuests.Add(quest.QuestName);
            }
        }
    }
}