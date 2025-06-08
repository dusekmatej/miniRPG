namespace miniRPG.Services.FileHandler;


public static class ConvertGameState
{
    // Not all the data from GameState are saved only the necessary ones, for better
    // performance and to avoid saving unnecessary data.
    
    
    // Mapping GameState properties for saving
    public static GameStateData ConvertToData()
    {
        return new GameStateData
        {
            CurrenciesMoney = GameState.Currencies.Money,
            MiningLastMaterial = GameState.Mining.LastMaterial,
            MiningStoneAmount = GameState.Mining.StoneAmount,
            MiningIronAmount = GameState.Mining.IronAmount,
            MiningGoldAmount = GameState.Mining.GoldAmount,
            MiningDiamondAmount = GameState.Mining.DiamondAmount,
            MiningEmeraldAmount = GameState.Mining.EmeraldAmount,
            MiningExperienceCurrent = GameState.Mining.Experience.Current,
            MiningExperienceLevel = GameState.Mining.Experience.Level,
            UpgradesSpeedLevel = GameState.Mining.Upgrades.SpeedLevel,
            CurrentColor = GameState.CurrentColor
        };
    }

    // Loading data back into GameState
    public static void LoadData(GameStateData data)
    {
        GameState.Currencies.Money = data.CurrenciesMoney;
        GameState.Mining.LastMaterial = data.MiningLastMaterial;
        GameState.Mining.StoneAmount = data.MiningStoneAmount;
        GameState.Mining.IronAmount = data.MiningIronAmount;
        GameState.Mining.GoldAmount = data.MiningGoldAmount;
        GameState.Mining.DiamondAmount = data.MiningDiamondAmount;
        GameState.Mining.EmeraldAmount = data.MiningEmeraldAmount;
        GameState.Mining.Experience.Current = data.MiningExperienceCurrent;
        GameState.Mining.Experience.Level = data.MiningExperienceLevel;
        GameState.Mining.Upgrades.SpeedLevel = data.UpgradesSpeedLevel;
        GameState.CurrentColor = data.CurrentColor;
    }
}