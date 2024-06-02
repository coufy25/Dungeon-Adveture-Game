public class Item
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }
    public int Healing { get; set; }

    public Item(string name, int price, int damage, int armor, int healing)
    {
        Name = name;
        Price = price;
        Damage = damage;
        Armor = armor;
        Healing = healing;
    }
}
