using RPG.Game;
using RPG.Backend;
using System.Text.Json;

namespace RPG.Backend.Save;

public class SavingLoadingSystem
{
    private static readonly string password = "jsjdpsdij";

    public static void SaveCharacter()
    {
        Directory.CreateDirectory("saves");
        string filename = $"saves/{Character.GetInstance().Name}.sav";
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Character.GetInstance(), options);
        File.WriteAllText(filename,Encryptor.Encrypt(jsonString, password));
        Console.WriteLine("Game saved");

#if DEBUG
        Console.WriteLine("Saved character to file: " + filename + "\n");
        Console.WriteLine(File.ReadAllText(filename));
#endif
    }

    public static void LoadCharacter(string name)
    {
        string jsonString = Encryptor.Decrypt(File.ReadAllText("saves/" + name + ".sav"), password);

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