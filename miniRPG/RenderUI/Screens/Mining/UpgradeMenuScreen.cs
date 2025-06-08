using miniRPG.RenderUI.ScreenLists;
using miniRPG.Services.Mining;

namespace miniRPG.RenderUI.Screens.Mining;

public class UpgradeMenuScreen : IScreen
{
    private int _selectedItem = 0;
    
    public void Render()
    {
        Console.Clear();
        
        
        Console.WriteLine("___  ____       _____________ _____ \n|  \\/  (_)     (_) ___ \\ ___ \\  __ \\\n| .  . |_ _ __  _| |_/ / |_/ / |  \\/\n| |\\/| | | '_ \\| |    /|  __/| | __ \n| |  | | | | | | | |\\ \\| |   | |_\\ \\\n\\_|  |_/_|_| |_|_\\_| \\_\\_|    \\____/\n                                    \n                                    ");
        Console.WriteLine($"Stone: {GameState.Mining.StoneAmount} Total inventory fill: {GameState.Mining.InventoryFill} Money: {GameState.Currencies.Money}");

        for (int i = 0; i < MiningMenuLists.UpgradeMenuScreen.Length; i++)
        {
            if (i == _selectedItem)
                Console.ForegroundColor = GameState.CurrentColor;
            
            Console.WriteLine(MiningMenuLists.UpgradeMenuScreen[i]);
            Console.ResetColor();
        }
    }

    public void SelectNext()
    {
        if (_selectedItem < MiningMenuLists.UpgradeMenuScreen.Length - 1)
        {
            _selectedItem++;
            return;
        }

        _selectedItem = 0;
    }

    public void SelectPrevious()
    {
        if (_selectedItem == 0)
        {
            _selectedItem = MiningMenuLists.UpgradeMenuScreen.Length - 1;
            return;
        }

        _selectedItem--;
    }

    public IScreen ConfirmSelection()
    {
        string selectedText = MiningMenuLists.UpgradeMenuScreen[_selectedItem];

        switch (selectedText)
        {
            case "Upgrade Inventory Size":
                Upgrade.InventorySize();
                return this;
            default:
                return this;
        }
    }
}