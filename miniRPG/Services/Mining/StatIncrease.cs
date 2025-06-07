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
                GameState.Mining.Experience.Current -= GameState.Mining.Experience.Intervals[GameState.Mining.Experience.Level];
                GameState.Mining.Experience.Level++;
            }
        }
    }
}