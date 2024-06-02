public class Boss : Enemy
{
    public Boss(string name, int health, int damage, double critChance, int critDamage, int x, int y)
        : base(name, health, damage, critChance, critDamage, x, y) { }
}
