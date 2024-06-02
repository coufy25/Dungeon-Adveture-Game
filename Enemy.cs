
public class Enemy
{

    public string Name { get; set; }
  
    public int Strength { get; set; }

    public int Health { get; set; }
   
    public double CriticalChance { get; set; }
    
    public int Damage { get; set; }
    // Pozice nepřítele na mapě (X souřadnice).
    public int X { get; set; }
    // Pozice nepřítele na mapě (Y souřadnice).
    public int Y { get; set; }

    // Konstruktor
    public Enemy(string name, int strength, int health, double criticalChance, int damage, int x, int y)
    {
        // vlastnosti nepřítele.
        Name = name;
        Strength = strength;
        Health = health;
        CriticalChance = criticalChance;
        Damage = damage;
        X = x;
        Y = y;
    }
}
