public class Profession
{
    public string Name { get; set; }
    public int Mana { get; set; }
    public int Stamina { get; set; }
    public double MagicPower { get; set; }
    public int PhysicalPower { get; set; }

    public Profession(string name, int mana, int stamina, double magicPower, int physicalPower)
    {
        Name = name;
        Mana = mana;
        Stamina = stamina;
        MagicPower = magicPower;
        PhysicalPower = physicalPower;
    }
}

