using miniRPG.Services.Mining;
using miniRPG.RenderUI.ScreenLists;
using miniRPG.RenderUI.Screens;
using miniRPG.Services;

namespace miniRPG.RenderUI.Screens.Mining;

public class MiningMenuScreen : IScreen
{
    private DiggingService _digService = new DiggingService();
    private int _selectedItem = 0;
    
    public void Render()
    {
        Console.Clear();
        Console.Write("-----   ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("MiniRPG");
        Console.ResetColor();
        Console.WriteLine("   -----");
        Console.WriteLine($"Stone: {GameState.Mining.StoneAmount} " +
                          $"Iron: {GameState.Mining.IronAmount} " +
                          $"Gold: {GameState.Mining.GoldAmount} " +
                          $"Diamond: {GameState.Mining.DiamondAmount} " +
                          $"Emerald: {GameState.Mining.EmeraldAmount}");

        for (int i = 0; i < MiningMenuLists.MiningMenuScreen.Length; i++)
        {
            if (i == _selectedItem)
                Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine(MiningMenuLists.MiningMenuScreen[i]);
            Console.ResetColor();
        }
    }

    public void SelectNext()
    {
        if (_selectedItem < MiningMenuLists.MiningMenuScreen.Length - 1)
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

        _selectedItem = MiningMenuLists.MiningMenuScreen.Length;
    }

    public IScreen ConfirmSelection()
    {
        string selectedText = MiningMenuLists.MiningMenuScreen[_selectedItem];

        switch (selectedText)
        {
            case "Dig":
                Logging.Log("Dig()");
                _digService.Dig();
                break;
            
            case "Smelt":
                break;
            
            case "Sell":
                return new SellMenuScreen();
                break; 
            
            case "Craft":
                break;
            
            case "Upgrade":
                break;
            
            case "<--":
                return new MainMenuScreen();
            
            default:
                return this;
                
        }

        return this;
    }
}