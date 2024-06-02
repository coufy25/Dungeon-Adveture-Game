public class Shop
{
    public void DisplayItems()
    {
        Console.WriteLine("1. Health Potion - 10 gold");
        Console.WriteLine("2. Sword - 20 gold");
    }

    public bool BuyItem(Player player, int itemNumber)
    {
        switch (itemNumber)
        {
            case 1:
                if (player.Money >= 10)
                {
                    player.Money -= 10;
                    player.Health += 20;
                    Console.WriteLine("You bought a health potion.");
                    return true;
                }
                break;
            case 2:
                if (player.Money >= 20)
                {
                    player.Money -= 20;
                    player.Damage += 5;
                    Console.WriteLine("You bought a sword.");
                    return true;
                }
                break;
        }
        return false;
    }
}