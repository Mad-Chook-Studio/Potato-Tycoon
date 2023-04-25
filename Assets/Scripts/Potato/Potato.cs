using System.Collections.Generic;
using UnityEngine;

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
    private List<PotatoSeasonGrowth> _growthValuesPerSeason;
    public List<PotatoSeasonGrowth> GrowthValuesPerSeason => _growthValuesPerSeason;

    [SerializeField]
    private int _maxGrowth;
    public int MaxGrowth => _maxGrowth;

    [SerializeField]
    private int _level;
    public int Level => _level;
}