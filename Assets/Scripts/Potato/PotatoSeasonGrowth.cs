using GameEnums;

[System.Serializable]
public struct PotatoSeasonGrowth
{
    public readonly float GrowthModifier;
    public readonly SeasonName SeasonName;

    public PotatoSeasonGrowth(float growthModifier, SeasonName seasonName)
    {
        GrowthModifier = growthModifier;
        SeasonName = seasonName;
    }
}