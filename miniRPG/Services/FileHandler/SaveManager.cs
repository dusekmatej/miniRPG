using System.Text.Json;
using miniRPG.Services.FileHandler;

namespace miniRPG.Services;

public class SaveManager
{
    
    // File Path variables
    private static readonly string SavePath =
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/miniRPG/save.json";
    
    private static readonly string SaveDirectory =
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/miniRPG";

    
    // Check if the directory exists, if not create it, then do the same for the save file.
    public static void FolderCheck()
    {
        if (Directory.Exists(SaveDirectory))
        {
            Logging.Log("Save directory found!");
        }
        else
        {
            Directory.CreateDirectory(SaveDirectory);
            Logging.Log("Save directory created");
        }
    }

    public static bool FileCheck()
    {
        if (File.Exists(SavePath))
        {
            Logging.Log("Save file found!");
            return true;
        }

        return false;
    }
    
    public static void Save()
    {
        var saveData = ConvertGameState.ConvertToData();
        var jsonSerializer = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
        
        File.WriteAllText(SavePath, jsonSerializer);
    }

    public static void Load()
    {
        if (!FileCheck())
        {
            Logging.Log("File hasn't been created yet, needed saving first!");
            return;
        }

        var readFile = File.ReadAllText(SavePath);
        var jsonDeserializer = JsonSerializer.Deserialize<GameStateData>(readFile);

        if (jsonDeserializer != null)
        {
            ConvertGameState.LoadData(jsonDeserializer);
            Logging.Log("Loaded!");
        }
        
        Logging.Log("File hasn't been loaded!");
    }
    
}