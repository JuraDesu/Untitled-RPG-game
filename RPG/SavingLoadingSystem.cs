using RPG.Game;
using System.Text.Json;

namespace RPG.Backend.Save;

public class SavingLoadingSystem
{
    public static void SaveCharacter()
    {
        Directory.CreateDirectory("saves");
        string filename = $"saves/{Character.GetInstance().Name}.json";
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Character.GetInstance(), options);
        File.WriteAllText(filename, jsonString);
        Console.WriteLine("Game saved");
#if DEBUG
        Console.WriteLine("Saved character to file: " + filename + "\n");
        Console.WriteLine(File.ReadAllText(filename));
#endif
    }

    public static void LoadCharacter(string name)
    {
        string jsonString = File.ReadAllText("saves/"+ name + ".json");
        
        var jsonDoc = JsonDocument.Parse(jsonString);
        int charClass = jsonDoc.RootElement.GetProperty("CharClass").GetInt32();

        switch (charClass)
        {
            case 1:
                CharacterFactory.GetInstance().Character = JsonSerializer.Deserialize<Warrior>(jsonString);
                break;
        }
    }
}