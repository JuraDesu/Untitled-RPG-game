﻿using ANSIConsole;
using ConsoleRPGV3;
using RPG.Backend;
using System.Text.Json;

namespace RPG.Game;

public class CharacterFactory
{
    private static CharacterFactory instance;
    private Character character;

    public static CharacterFactory GetInstance()
    {
        if (instance == null)
        {
            return new CharacterFactory();
        }
        return instance;
    }
    public void CreateCharacter()
    {
        string name;
        
        Console.Clear();
        Console.WriteLine("Hello there! So you want to dive into the world of [INSERT NAME HERE]");
        Console.Write("Shall I know your name?" +  "[" + "Enter name".Color(ConsoleColor.Cyan) + "]$: ");
        name = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"Hello {name}, now it's time to select a class type use numbers to select a class\n");
        Console.WriteLine(FileLoader.GetFileContent("Classes"));
        Console.Write("[" + "Class Selection".Color(ConsoleColor.Cyan)+ "]$: ");
        SelectClass(int.Parse(Console.ReadLine()), name);
        Console.Clear();
    }

    private void SelectClass(int classNumber, string name)
    {
        switch (classNumber)
        {
            case 1:
                character = new Warrior(name);
                break;
            default:
                Console.WriteLine("Other classes WIP");
                break;
        }
    }

    public void SaveCharacter()
    {
        Directory.CreateDirectory("saves");
        string filename = $"saves/{Character.GetInstance().Name}.json";
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Character.GetInstance(), options);
        File.WriteAllText(filename, jsonString);
#if DEBUG
        Console.WriteLine("Saved character to file: " + filename + "\n");
        Console.WriteLine(File.ReadAllText(filename));
#endif
    }

    public void LoadCharacter(string name)
    {
        string jsonString = File.ReadAllText("saves/"+ name + ".json");
        
        var jsonDoc = JsonDocument.Parse(jsonString);
        int charClass = jsonDoc.RootElement.GetProperty("CharClass").GetInt32();

        switch (charClass)
        {
            case 1:
                character = JsonSerializer.Deserialize<Warrior>(jsonString);
                break;
        }
    }
}