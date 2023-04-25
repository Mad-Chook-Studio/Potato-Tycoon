using System;
using GameEnums;
using UnityEngine;

namespace Potatoes
{
    [Serializable]
    public struct PotatoSeasonGrowth
    {
        [field: SerializeField]
        public float GrowthModifier { get; private set; }
        
        [field: SerializeField]
        public SeasonName SeasonName { get; private set; }

        public PotatoSeasonGrowth(float growthModifier, SeasonName seasonName)
        {
            GrowthModifier = growthModifier;
            SeasonName = seasonName;
        }
    }
}