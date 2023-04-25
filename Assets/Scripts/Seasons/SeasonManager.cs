using System.Collections.Generic;
using GameEnums;

namespace Seasons
{
    public class SeasonManager
    {
        private readonly List<Season> _seasons = new()
        {
            new Season(SeasonName.Summer),
            new Season(SeasonName.Autumn),
            new Season(SeasonName.Winter),
            new Season(SeasonName.Spring),
        };


        private Season _currentSeason = _seasons[0];
        public Season CurrentSeason { get; private set; } = _seasons[0];
    }
}