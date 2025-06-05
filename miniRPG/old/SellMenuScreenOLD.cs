

/*
using miniRPG.RenderUI.ScreenLists;
using miniRPG.Services.Mining;

namespace miniRPG.RenderUI.Screens.Mining;
{
    private readonly SellService _sellService = new SellService();
    
    private int _selectedItem = 0;
    
    public void Render()
    {
        Console.Clear();
        
        var resources = new Dictionary<string, int>
        {
            { "StoneAmount", GameState.Mining.StoneAmount },
            { "Iron", GameState.Mining.Iron },
            { "Gold", GameState.Mining.Gold },
            { "Diamond", GameState.Mining.Diamond },
            { "Emerald", GameState.Mining.Emerald }
        };
        
        foreach (var resource in resources)
        {
            if (resource.Value > 0)
            {
                Console.WriteLine($"{resource.Key}: {resource.Value}");
            }
        }
        
        var filteredMenu = MiningMenuLists.SellMenuScreen
            .Where(item => resources.Any(r => item.Contains(r.Key.ToLower()) && r.Value > 0))
            .ToArray();
        
        for (int i = 0; i < filteredMenu.Length; i++)
        {
            if (i == _selectedItem)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(filteredMenu[i]);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(filteredMenu[i]);
            }
        }
    }

    public void SelectNext()
    {
        var filteredMenu = MiningMenuLists.SellMenuScreen
            .Where(item => new Dictionary<string, int>
            {
                { "StoneAmount", GameState.Mining.StoneAmount },
                { "Iron", GameState.Mining.Iron },
                { "Gold", GameState.Mining.Gold },
                { "Diamond", GameState.Mining.Diamond },
                { "Emerald", GameState.Mining.Emerald }
            }.Any(r => item.Contains(r.Key.ToLower()) && r.Value > 0))
            .ToArray();
        
        if (_selectedItem < filteredMenu.Length  - 1)
        {
            _selectedItem++;
            return;
        }
        else
        {
            _selectedItem = 0;
        }
    }

    public void SelectPrevious()
    {
        var filteredMenu = MiningMenuLists.SellMenuScreen
            .Where(item => new Dictionary<string, int>
            {
                { "StoneAmount", GameState.Mining.StoneAmount },
                { "Iron", GameState.Mining.Iron },
                { "Gold", GameState.Mining.Gold },
                { "Diamond", GameState.Mining.Diamond },
                { "Emerald", GameState.Mining.Emerald }
            }.Any(r => item.Contains(r.Key.ToLower()) && r.Value > 0))
            .ToArray();
        
        
        if (_selectedItem > 0)
        {
            _selectedItem--;
            return;
        }
        else
        {
            _selectedItem = filteredMenu.Length - 1;
        }
    }

    public IScreen ConfirmSelection()
    {
        var filteredMenu = MiningMenuLists.SellMenuScreen
            .Where(item => new Dictionary<string, int>
            {
                { "StoneAmount", GameState.Mining.StoneAmount },
                { "Iron", GameState.Mining.Iron },
                { "Gold", GameState.Mining.Gold },
                { "Diamond", GameState.Mining.Diamond },
                { "Emerald", GameState.Mining.Emerald }
            }.Any(r => item.Contains(r.Key.ToLower()) && r.Value > 0))
            .ToArray();
        
        
        if (_selectedItem >= filteredMenu.Length)
        {
            return this;
        }
        
        string selectedText = filteredMenu[_selectedItem];

        switch (selectedText)
        {
            case "Sell StoneAmount":
                _sellService.Sell("stone");
                break;
            case "Sell Iron":
                _sellService.Sell("iron");
                break;
            case "Sell Gold":
                _sellService.Sell("gold");
                break;
            case "Sell Diamond":
                _sellService.Sell("diamond");
                break;
            case "Sell Emerald":
                _sellService.Sell("emerald");
                break;
            default:
                return this;
        }

        return this;
    }
}*/