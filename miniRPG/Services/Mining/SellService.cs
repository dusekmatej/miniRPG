namespace miniRPG.Services.Mining;

public class SellService
{
    private Dictionary<string, Func<int>> _resourceMapping = new()
    {
        { "stone", () => GameState.Mining.StoneAmount },
        { "iron", () => GameState.Mining.IronAmount },
        { "gold", () => GameState.Mining.GoldAmount },
        { "diamond", () => GameState.Mining.DiamondAmount },
        { "emerald", () => GameState.Mining.EmeraldAmount }
    };
    
    public void Sell(string resourceName)
    {
        GameState.IsRunning = false;
        if (!_resourceMapping.ContainsKey(resourceName))
        {
            Messages.Error("Invalid resource name");
        }
        
        int amountToSell = Quantity(resourceName);
        Logging.Log("Quantity to sell: " + amountToSell);

        if (amountToSell > 0 && GetResource(resourceName) >= amountToSell)
            SetResource(resourceName, amountToSell);

        GameState.IsRunning = true;
    }

    private int GetResource(string resourceName)
    {
        if (_resourceMapping.ContainsKey(resourceName))
        {
            return _resourceMapping[resourceName]();
        }
        
        Logging.Log("Missing resource mapping for: " + resourceName);

        return 0;
    }
    
    private void SetResource(string resourceName, int value)
    {
        if (_resourceMapping.ContainsKey(resourceName))
        {
            switch (resourceName)
            {
                case "stone":
                    GameState.Mining.StoneAmount -= value;
                    GameState.Currencies.Money += value * GameState.Mining.Store.StoneSellPrice;
                    StatIncrease.MiningStats.GainExperience(GameState.Mining.Experience.StoneSell * value);
                    break;
                case "iron":
                    GameState.Mining.IronAmount -= value;
                    GameState.Currencies.Money += value * GameState.Mining.Store.IronSellPrice;
                    StatIncrease.MiningStats.GainExperience(GameState.Mining.Experience.IronSell * value);
                    break;
                case "gold":
                    GameState.Mining.GoldAmount -= value;
                    GameState.Currencies.Money += value * GameState.Mining.Store.GoldSellPrice;
                    StatIncrease.MiningStats.GainExperience(GameState.Mining.Experience.GoldSell * value);
                    break;
                case "diamond":
                    GameState.Mining.DiamondAmount -= value;
                    GameState.Currencies.Money += value * GameState.Mining.Store.DiamondSellPrice;
                    StatIncrease.MiningStats.GainExperience(GameState.Mining.Experience.DiamondSell * value);
                    break;
                case "emerald":
                    GameState.Mining.EmeraldAmount -= value;
                    GameState.Currencies.Money += value * GameState.Mining.Store.EmeraldSellPrice;
                    StatIncrease.MiningStats.GainExperience(GameState.Mining.Experience.EmeraldSell * value);
                    break;
            }
        }
    }

    private int Quantity(string resourceName)
    {
        Console.WriteLine("Do you want to sell all or specific amount? (Enter a number or type 'all' to sell all): ");
        string input = Console.ReadLine().ToLower();

        if (input == "all")
        {
            Logging.Log("Selling all of " + resourceName + "Resource amount" + GetResource(resourceName));
            return GetResource(resourceName);
        }

        if (!int.TryParse(input, out int quantity))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Please enter a valid number or 'all'");
            Console.ResetColor();
            Console.ReadKey(true);

            return 0;
        }

        return quantity;
    }
}