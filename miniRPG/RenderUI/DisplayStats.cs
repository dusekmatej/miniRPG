namespace miniRPG.RenderUI;

public static class DisplayStats
{
    public static string SellMiningStats()
    {
        return $"Stone: {GameState.Mining.StoneAmount} " +
                          $"Iron: {GameState.Mining.IronAmount} " +
                          $"Gold: {GameState.Mining.GoldAmount} " +
                          $"Diamond: {GameState.Mining.DiamondAmount} " +
                          $"Emerald: {GameState.Mining.EmeraldAmount} " +
                          $"Money: {GameState.Currencies.Money} " +
                          $"Level: {GameState.Mining.Experience.Level} " +
                          $"Experience: {GameState.Mining.Experience.Current} " +
                          $"Inventory Size: {GameState.Mining.InventoryFill}/{GameState.Mining.Upgrade.InventorySize[GameState.Mining.Upgrade.InventorySizeLevel]}";
    }

}