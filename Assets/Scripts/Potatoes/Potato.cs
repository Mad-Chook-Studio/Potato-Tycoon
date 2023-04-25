using System.Collections.Generic;
using GameEnums;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Potatoes
{
    [CreateAssetMenu(fileName = "NewPotato", menuName = "Potato Tycoon/Potato", order = 0)]
    public class Potato : ScriptableObject
    {
        [SerializeField]
        private string _potatoName;
        public string PotatoName => _potatoName;

        [SerializeField]
        private Sprite _potatoSprite;
        public Sprite PotatoSprite => _potatoSprite;

        [SerializeField]
        private List<PotatoSeasonGrowth> _growthValuesPerSeason = new List<PotatoSeasonGrowth>()
        {
            new PotatoSeasonGrowth(1.0f, SeasonName.Autumn),
            new PotatoSeasonGrowth(1.0f, SeasonName.Spring),
            new PotatoSeasonGrowth(1.0f, SeasonName.Summer),
            new PotatoSeasonGrowth(1.0f, SeasonName.Winter),
        };
        public List<PotatoSeasonGrowth> GrowthValuesPerSeason => _growthValuesPerSeason;

        [SerializeField]
        private int _maxGrowth;
        public int MaxGrowth => _maxGrowth;

        [SerializeField] private int _value;
        public int Value => _value;

        [SerializeField]
        private int _level;
        public int Level => _level;
    }
}