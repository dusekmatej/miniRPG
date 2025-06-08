namespace miniRPG.Services.Mining;

public static class StatIncrease
{
    public static class MiningStats
    {
        public static void GainExperience(int experienceAmount)
        {
            GameState.Mining.Experience.Current += experienceAmount;

            while (GameState.Mining.Experience.Level < GameState.Mining.Experience.Intervals.Length && 
                   GameState.Mining.Experience.Current >= GameState.Mining.Experience.Intervals[GameState.Mining.Experience.Level])
            {
                NextLevel();
            }
        }
    }

    private static void NextLevel()
    {
        Console.Clear();
        GameState.Mining.Experience.Current -= GameState.Mining.Experience.Intervals[GameState.Mining.Experience.Level];
        GameState.Mining.Experience.Level++;

        Console.ForegroundColor = ConsoleColor.Red;
        // ASCII art for level up
        Console.WriteLine(" _                    _          _               \n| |                  | |        | |              \n| |     _____   _____| | ___  __| |  _   _ _ __  \n| |    / _ \\ \\ / / _ \\ |/ _ \\/ _` | | | | | '_ \\ \n| |___|  __/\\ V /  __/ |  __/ (_| | | |_| | |_) |\n\\_____/\\___| \\_/ \\___|_|\\___|\\__,_|  \\__,_| .__/ \n                                          | |    \n                                          |_|    ");
        Console.ResetColor();
        Console.WriteLine($"Congratulations! You have reached level {GameState.Mining.Experience.Level} in Mining!");
        Console.ReadKey();
    }
}