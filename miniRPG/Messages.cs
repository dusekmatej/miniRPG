namespace miniRPG;

public static class Messages
{
    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: " + message);
        Console.ResetColor();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}