using miniRPG.RenderUI.ScreenLists;

namespace miniRPG.RenderUI.Screens.MainMenu;

public class ColorSelectionScreen :IScreen
{
    private int _selectedItem = 0;
    
    public void Render()
    {
        Console.Clear();
        
        for (int i = 0; i < MainMenuLists.ColorOptions.Length; i++)
        {
            if (i == _selectedItem)
                Console.ForegroundColor = GameState.CurrentColor;
            
            Console.WriteLine(MainMenuLists.ColorOptions[i]);
            Console.ResetColor();
        }
    }

    public void SelectNext()
    {
        if (_selectedItem < MainMenuLists.ColorOptions.Length - 1)
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
        string selectedText = MainMenuLists.ColorOptions[_selectedItem];

        switch (selectedText)
        {
            case "Red":
                GameState.CurrentColor = ConsoleColor.Red;
                return this;
            case "Green":
                GameState.CurrentColor = ConsoleColor.Green;
                return this;
            case "Blue":
                GameState.CurrentColor = ConsoleColor.Blue;
                return this;
            case "Yellow":
                GameState.CurrentColor = ConsoleColor.Yellow;
                return this;
            case "Cyan":
                GameState.CurrentColor = ConsoleColor.Cyan;
                return this;
            case "Magenta":
                GameState.CurrentColor = ConsoleColor.Magenta;
                return this;
            case "White":
                GameState.CurrentColor = ConsoleColor.White;
                return this;
            case "Black":
                GameState.CurrentColor = ConsoleColor.Black;
                return this;
            case "<--":
                return new OptionsScreen();
            default: return this;
        }
    }
}