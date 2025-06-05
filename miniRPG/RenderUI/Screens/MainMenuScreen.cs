using miniRPG.RenderUI.ScreenLists;
using miniRPG.RenderUI.Screens.Mining;

namespace miniRPG.RenderUI.Screens;

public class MainMenuScreen : IScreen
{
    private int _selectedItem = 0;
    
    public void Render()
    {
        Console.Clear();
        
        Console.WriteLine($"Stone: {GameState.Mining.StoneAmount} Total inventory fill: {GameState.Mining.InventoryFill} Money: {GameState.Currencies.Money}");

        for (int i = 0; i < MainMenuLists.MainMenuScreen.Length; i++)
        {
            if (i == _selectedItem)
                Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine(MainMenuLists.MainMenuScreen[i]);
            Console.ResetColor();
        }
    }

    public void SelectNext()
    {
        if (_selectedItem < MainMenuLists.MainMenuScreen.Length - 1)
        {
            _selectedItem++;
            return;
        }

        _selectedItem = 0;
    }

    public void SelectPrevious()
    {
        if (_selectedItem > 0)
        {
            _selectedItem--;
            return;
        }

        _selectedItem = MainMenuLists.MainMenuScreen.Length;
    }

    public IScreen ConfirmSelection()
    {
        string selectedText = MainMenuLists.MainMenuScreen[_selectedItem];

        switch (selectedText)
        {
            case "Mining":
                return new MiningMenuScreen();
            
            case "Woodworking":
                throw new NotImplementedException();
            
            default:
                return this;
        }
    }
}