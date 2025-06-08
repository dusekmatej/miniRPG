namespace miniRPG.Services.Mining;

public class DiggingService
{
    private Random _random = new Random();
    private int _randomChance;

    private int _currentLoad = 0;
    private int _maxLoad = 10;
    
    public void Dig()
    {
        if (!Upgrade.CalculateInventorySize())
        {
            Console.WriteLine("Your inventory is full! Sell resource or upgrade your inventory size.");
            Console.ReadKey(true);
            return;
        }
        
        Loading();
        GenerateResource();
        Logging.Log($"Digging action performed: {GameState.Mining.LastMaterial}");
        Console.ReadKey(true);
    }

    private void Loading()
    {
        Console.Clear();
        Console.WriteLine("[     ]");
        for (int i = 0; i < 10; i++)
        {
            _currentLoad++;
            _maxLoad--;
            
            Console.Clear();
            Console.WriteLine($"[{new string('#', _currentLoad)}{new string(' ', _maxLoad)}] digging...");
            Thread.Sleep(100);
        }

        _currentLoad = 0;
        _maxLoad = 10;
    }
    
    private void GenerateResource()
    {
        _randomChance = _random.Next(100);

        if (_randomChance < 40)
        {
            GameState.Mining.StoneAmount++;
            GameState.Mining.LastMaterial = "stone";
            Console.WriteLine("Found stone!");
        }
        else if (_randomChance < 65)
        {
            GameState.Mining.IronAmount++;
            GameState.Mining.LastMaterial = "iron";
            Console.WriteLine("You found Iron!");
        }
        else if (_randomChance < 80)
        {
            GameState.Mining.GoldAmount++;
            GameState.Mining.LastMaterial = "gold";
            Console.WriteLine("Found Gold!");
        }
        else if (_randomChance < 90)
        {
            GameState.Mining.DiamondAmount++;
            GameState.Mining.LastMaterial = "diamond";
            Console.WriteLine("Found Diamond!");
        }
        else
        {
            GameState.Mining.EmeraldAmount++;
            GameState.Mining.LastMaterial = "emerald";
            Console.WriteLine("Found Emerald!");
        }
        
        
    }
}