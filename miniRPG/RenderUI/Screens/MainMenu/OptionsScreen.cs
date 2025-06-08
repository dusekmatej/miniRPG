using miniRPG.RenderUI.ScreenLists;

namespace miniRPG.RenderUI.Screens.MainMenu;

public class OptionsScreen :IScreen
{
    private int _selectedItem = 0;
    
    public void Render()
    {
        Console.Clear();
        
        for (int i = 0; i < MainMenuLists.OptionsScreen.Length; i++)
        {
            if (i == _selectedItem)
                Console.ForegroundColor = GameState.CurrentColor;
            
            Console.WriteLine(MainMenuLists.OptionsScreen[i]);
            Console.ResetColor();
        }
    }

    public void SelectNext()
    {
        if (_selectedItem < MainMenuLists.OptionsScreen.Length - 1)
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
            _selectedItem = MainMenuLists.MainMenuScreen.Length - 1;
            return;
        }

        _selectedItem--;
    }

    public IScreen ConfirmSelection()
    {
        string selectedText = MainMenuLists.OptionsScreen[_selectedItem];

        switch (selectedText)
        {
            case "Change Color":
                return new ColorSelectionScreen();
            case "<--":
                return new MainMenuScreen();
            default:
                return this;
        }
    }
}