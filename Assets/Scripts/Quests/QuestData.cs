namespace Quests
{
    public class QuestData
    {
        public Quest Quest { get; private set; }
        public int Progress { get; private set; }

        public QuestData()
        {
        }

        public QuestData(Quest quest, int progress = 0)
        {
            Quest = quest;
            Progress = progress;
        }

        public void UpdateQuestProgress(int value) => Progress += value;
    }
}