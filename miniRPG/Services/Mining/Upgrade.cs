namespace miniRPG.Services.Mining;

public class Upgrade
{
    public static bool CalculateInventorySize()
    {
        int totalFill = GameState.Mining.StoneAmount + GameState.Mining.IronAmount
                                                     + GameState.Mining.GoldAmount + GameState.Mining.DiamondAmount +
                                                       GameState.Mining.EmeraldAmount;
        
        if (totalFill <= GameState.Mining.Upgrade.InventorySize[GameState.Mining.Upgrade.InventorySizeLevel])
            return true;

        return false;
    }
    
    public static int GetCurrentFill()
    {
        return GameState.Mining.StoneAmount + GameState.Mining.IronAmount
                                             + GameState.Mining.GoldAmount + GameState.Mining.DiamondAmount +
                                               GameState.Mining.EmeraldAmount;
    }
    
    public static void InventorySize()
    {
        if (GameState.Currencies.Money < GameState.Mining.Upgrade.InventorySizeCost[GameState.Mining.Upgrade.InventorySizeLevel]) 
            GameState.Mining.Upgrade.InventorySizeLevel++;
    }
}