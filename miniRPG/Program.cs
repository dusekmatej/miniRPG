using miniRPG.RenderUI.Screens;
using miniRPG.Services;

// TODO: Make the ui better with bigger texts such as LEVEL UP text in big when you LEVEL UP
// TODO: And try to make the whole game more pretty, so its more fun cause of the looks


namespace miniRPG
{
    static class Program
    {
        public static void Main(String[] args)
        {
            // Check if the folder exists, if not create it
            SaveManager.FolderCheck();
            
            // Load stats if file exists
            SaveManager.Load();
            
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
            
            // Save the game
            SaveManager.Save();
        }
    }
}