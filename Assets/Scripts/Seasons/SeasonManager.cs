using System.Collections.Generic;
using GameEnums;
using Potatoes;

namespace Seasons
{
    public class SeasonManager
    {
        private static readonly List<Season> Seasons = new()
        {
            new Season(SeasonName.Summer),
            new Season(SeasonName.Autumn),
            new Season(SeasonName.Winter),
            new Season(SeasonName.Spring)
        };

        public Season CurrentSeason { get; private set; } = Seasons[0];
        
        // Calculate the seasonal growth rate for a potato species
        public float GetSeasonalGrowthRate(Potato potato)
        {
            PotatoSeasonGrowth potatoGrowth =
                potato.GrowthValuesPerSeason.Find(x => x.SeasonName == CurrentSeason.SeasonName);
                
            return potatoGrowth.GrowthModifier;
        }

        public void SetSeason(Season season) => CurrentSeason = season;
    }
}