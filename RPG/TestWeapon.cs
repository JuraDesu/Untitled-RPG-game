using RPG.Game;

namespace ConsoleRPGV3;

public class TestWeapon : Weapon
{
    public TestWeapon()
    {
        name = "Prdel";
        minDamage = 10;
        maxDamage = 20;
        reqClass = CharacterClass.Warrior;
    }
}