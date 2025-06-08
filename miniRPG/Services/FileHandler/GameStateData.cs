namespace miniRPG;


// Note: only the properties that need to be saved should be included here.

public class GameStateData
{
    // Currencies
    public int CurrenciesMoney { get; set; }
    
    // Mining part
    public string MiningLastMaterial { get; set; }
    public int MiningStoneAmount { get; set; }
    public int MiningIronAmount { get; set; }
    public int MiningGoldAmount { get; set; }
    public int MiningDiamondAmount { get; set; }
    public int MiningEmeraldAmount { get; set; }
    
    public int MiningExperienceCurrent { get; set; }
    public int[] MiningExperienceIntervals { get; set; }
    public int MiningExperienceLevel { get; set; } 

    public int UpgradesSpeedLevel { get; set; }
}