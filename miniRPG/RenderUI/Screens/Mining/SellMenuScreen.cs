using miniRPG.RenderUI.ScreenLists;
using miniRPG.Services.Mining;

namespace miniRPG.RenderUI.Screens.Mining;

public class SellMenuScreen : IScreen
{
    private readonly SellService _sellService = new SellService();
    private int _selectedItem = 0;
    private string[] _cachedFilteredMenu = Array.Empty<string>();

    private string[] GetFilteredMenu()
    {
        var resources = new Dictionary<string, int>
        {
            { "stone", GameState.Mining.StoneAmount },
            { "iron", GameState.Mining.IronAmount },
            { "gold", GameState.Mining.GoldAmount },
            { "diamond", GameState.Mining.DiamondAmount },
            { "emerald", GameState.Mining.EmeraldAmount }
        };

        var filtered = MiningMenuLists.SellMenuScreen
            .Where(item =>
            {
                var lowerItem = item.ToLower();
                return lowerItem == "<--" || resources.Any(r => lowerItem.Contains(r.Key) && r.Value > 0);
            })
            .ToArray();

        return filtered;
    }
    
    public void Render()
    {
        Console.Clear();

        _cachedFilteredMenu = GetFilteredMenu();
        
        Console.WriteLine(DisplayStats.SellMiningStats());
        
        for (int i = 0; i < _cachedFilteredMenu.Length; i++)
        {
            if (i == _selectedItem)
            {
                Console.ForegroundColor = GameState.CurrentColor;
                Console.WriteLine($"> {_cachedFilteredMenu[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {_cachedFilteredMenu[i]}");
            }
        }
    }

    public void SelectNext()
    {
        if (_cachedFilteredMenu.Length == 0) return;
        _selectedItem = (_selectedItem + 1) % _cachedFilteredMenu.Length;
    }

    public void SelectPrevious()
    {
        if (_selectedItem == 0)
        {
            _selectedItem = MainMenuLists.MainMenuScreen.Length - 1;
            return;
        }

        _selectedItem--;
    }

    public IScreen ConfirmSelection()
    {
        if (_cachedFilteredMenu.Length == 0 || _selectedItem >= _cachedFilteredMenu.Length)
            return this;

        string selectedText = _cachedFilteredMenu[_selectedItem];

        switch (selectedText)
        {
            case "Sell Stone":
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
            case "<--":
                return new MiningMenuScreen();
        }

        return this;
    }
}
