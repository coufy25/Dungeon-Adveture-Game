
public class Player
{
    private string playerName;
    private Race playerRace;
    private Profession playerProfession;
    private int startX;
    private int startY;

    public string Name { get; set; }
    public Race PlayerRace { get; set; }
    public Profession PlayerProfession { get; set; }
    public RaceAttributes Attributes { get; }
    public int Strength { get; set; }
    public int Health { get; set; }
    public double CriticalChance { get; set; }
    public int Damage { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    public int Money { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Player(string name, Race race, Profession profession, int x, int y)
    {
        Name = name;
        PlayerRace = race;
        PlayerProfession = profession;
        X = x;
        Y = y;
        Strength = 10;
        Health = 100;
        CriticalChance = 0.1;
        Damage = 10;
        Experience = 0;
        Level = 1;
        Money = 0;
    }


    // Metoda pro pohyb hráče na mapě podle daného směru.
    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                if (X > 0) X--; // Změna X souřadnice na severu.
                break;
            case Direction.South:
                if (X < 9) X++; // Změna X souřadnice na jihu.
                break;
            case Direction.East:
                if (Y < 9) Y++; // Změna Y souřadnice na východě.
                break;
            case Direction.West:
                if (Y > 0) Y--; // Změna Y souřadnice na západě.
                break;
        }
    }

    // Metoda pro získání XP hráčem.
    public void GainExperience(int amount)
    {
        Experience += amount; // Získání XP.
        if (Experience >= Level * 100) // Pokud hráč dosáhl dostatečného množství zkušeností pro level up.
        {
            Level++; // Zvýšení levelu.
            Experience = 0; // Resetování XP.
            Strength += 2; // Zvýšení síly.
            Health += 20; // Zvýšení zdraví.
            Damage += 5; // Zvýšení útoku.
            Console.WriteLine($"You leveled up! Level: {Level}, Strength: {Strength}, Health: {Health}, Damage: {Damage}");
        }
    }

    // Metoda pro odebrání zdraví hráči.
    public void TakeDamage(int damage)
    {
        Health -= damage; // Odebrání zdraví.
        if (Health < 0) // Pokud hráč ztratil všechno zdraví.
        {
            Health = 0; // Nastavení zdraví na nulu.
            Console.WriteLine($"{Name} was defeated."); // Výpis, že hráč byl poražen.
        }
    }
}



