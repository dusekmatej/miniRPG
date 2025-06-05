namespace miniRPG.Services;

public static class Logging
{
    private static StreamWriter? _streamWriter;

    private const string? DateFormat = "yyyy-MM-dd HH-mm-ss";
    
    private static string? _currentDate;
    private static string? _fullPath;
    private static string? _directoryPath;
    
    public static void Entry()
    {
        _currentDate = DateTime.Now.ToString(DateFormat);
        _directoryPath = "Logs";
        _fullPath = Path.Combine(_directoryPath + $"/Log-{_currentDate}");
        InstanceCreation();
    }

    private static void InstanceCreation()
    {
        if (!Directory.Exists(_directoryPath) && _directoryPath != null)
        {
            Directory.CreateDirectory(_directoryPath);
        }

        if (_fullPath != null)
        {
            _streamWriter = new StreamWriter(_fullPath);
            _streamWriter.AutoFlush = true;
        }

        GameState.LogEntered = true;
    }

    public static void Log(string message)
    {
        if ((Directory.Exists(_directoryPath) && (File.Exists(_fullPath))) && (GameState.LogEntered && GameState.LogAllowed))
        {
            _currentDate = DateTime.Now.ToString(DateFormat);
            string logMessage = _currentDate + " - " + message;
            _streamWriter.WriteLine(logMessage);
        }
    }
}