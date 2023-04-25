using System.Collections.Generic;
using GameEnums;

namespace Seasons
{
    public class SeasonManager
    {
        private static readonly List<Season> Seasons = new()
        {
            new Season(SeasonName.Summer),
            new Season(SeasonName.Autumn),
            new Season(SeasonName.Winter),
            new Season(SeasonName.Spring),
        };

        private Season _currentSeason = Seasons[0];
        public Season CurrentSeason { get; private set; } = Seasons[0];
        
        // Calculate the seasonal growth rate for a potato species
        public float GetSeasonalGrowthRate(Potato potato)
        {
            PotatoSeasonGrowth potatoGrowth =
                potato.GrowthValuesPerSeason.Find(x => x.Season == CurrentSeason.season);
                
            return potatoGrowth.GrowthModifier;
        }
    }
}