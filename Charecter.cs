public abstract class Character
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Health { get; set; }
    public double CriticalChance { get; set; }
    public int Damage { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }

    protected Character(string name, int strength, int health, double criticalChance, int damage, int x, int y)
    {
        Name = name;
        Strength = strength;
        Health = health;
        CriticalChance = criticalChance;
        Damage = damage;
        X = x;
        Y = y;
        Experience = 0;
        Level = 1;
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                if (Y > 0) Y--; // Změna Y souřadnice na severu.
                else Console.WriteLine("You can't move further north."); // Pokud je postava na horním okraji mapy.
                break;
            case Direction.South:
                if (Y < 9) Y++; // Změna Y souřadnice na jihu.
                else Console.WriteLine("You can't move further south."); // Pokud je postava na dolním okraji mapy.
                break;
            case Direction.East:
                if (X < 9) X++; // Změna X souřadnice na východě.
                else Console.WriteLine("You can't move further east."); // Pokud je postava na pravém okraji mapy.
                break;
            case Direction.West:
                if (X > 0) X--; // Změna X souřadnice na západě.
                else Console.WriteLine("You can't move further west."); // Pokud je postava na levém okraji mapy.
                break;
        }
    }
}
