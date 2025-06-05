using miniRPG.RenderUI.Screens;
using miniRPG.Services;

namespace miniRPG
{
    static class Program
    {
        public static void Main(String[] args)
        {
            Logging.Entry();
            
            IScreen currentScreen = new MainMenuScreen(); 
            
            while (GameState.IsRunning)
            {
                currentScreen.Render();
                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        currentScreen.SelectPrevious();
                        break;
            
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        currentScreen.SelectNext();
                        break;
            
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        currentScreen = currentScreen.ConfirmSelection();
                        break;
                }
                currentScreen.Render();
            }
        }
    }
}