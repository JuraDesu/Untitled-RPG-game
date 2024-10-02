using RPG.Game;

namespace RPG.Game;

public enum ArmorType
{
    None = 0,
    Helmet,
    Chestplate,
    Pants,
    Boots,
}

public class Armor
{
    private string name;
    private int armor;
    private CharacterClass RequiredClass;
    private ArmorType armorType;
    private Attributes attributes;

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Armor1
    {
        get => armor;
        set => armor = value;
    }

    public CharacterClass RequiredClass1
    {
        get => RequiredClass;
        set => RequiredClass = value;
    }

    public ArmorType ArmorType
    {
        get => armorType;
        set => armorType = value;
    }

    public Attributes Attributes
    {
        get => attributes;
        set => attributes = value;
    }
}