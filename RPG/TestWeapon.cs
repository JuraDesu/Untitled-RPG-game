using RPG.Game;

namespace RPG.Items.Test;

public class TestWeapon : Weapon
{
    public TestWeapon()
    {
        rarity = Rarity.Uncommon;
        SetRarityColor();
        name = "Prdel";
        minDamage = 10;
        maxDamage = 20;
        reqClass = CharacterClass.Warrior;
    }
}