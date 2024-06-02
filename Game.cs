using System;

namespace Zaverecny__projekt_PV
{
    public enum Race
    {
        Human,
        Elf,
        Dwarf,
        Hobbit,
        Troll,
        Orc,
        Goblin
    }
    public class Game
    {
        private Player Player { get; set; }
        private Room[,] Rooms { get; set; }

       
        public Game(string playerName, Race race, Profession playerProfession, int startX, int startY)
        {
            Player = new Player(playerName, (global::Race)race, playerProfession, startX, startY);
            Rooms = new Room[10, 10];
            InitializeEnemies();
            InitializeRooms();
            Start();
        }

        private void InitializeEnemies()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (rand.Next(0, 100) < 30) // 30% šance, že v místnosti bude nepřítel
                    {
                        var enemyType = rand.Next(0, 3);
                        Enemy enemy;
                        switch (enemyType)
                        {
                            case 0:
                                enemy = new Enemy("Goblin", 3, 20, 0.05, 5, i, j);
                                break;
                            case 1:
                                enemy = new Enemy("Orc", 5, 30, 0.1, 10, i, j);
                                break;
                            case 2:
                                enemy = new Enemy("Troll", 8, 40, 0.15, 15, i, j);
                                break;
                            default:
                                enemy = new Enemy("Goblin", 3, 20, 0.05, 5, i, j);
                                break;
                        }
                        Rooms[i, j] = new Room(RoomType.Enemy, enemy);
                    }
                }
            }
        }

        private void InitializeRooms()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Rooms[i, j] == null)
                    {
                        int roomTypeChance = rand.Next(0, 100);
                        if (roomTypeChance < 60)
                        {
                            Rooms[i, j] = new Room(RoomType.Empty);
                        }
                        else if (roomTypeChance < 80)
                        {
                            var enemy = new Enemy("Goblin", 3, 20, 0.05, 5, i, j);
                            Rooms[i, j] = new Room(RoomType.Enemy, enemy);
                        }
                        else if (roomTypeChance < 90)
                        {
                            Rooms[i, j] = new Room(RoomType.Treasure, treasure: rand.Next(10, 50));
                        }
                        else if (roomTypeChance < 95)
                        {
                            var boss = new Enemy("Dragon", 20, 100, 0.1, 25, i, j);
                            Rooms[i, j] = new Room(RoomType.Boss, boss);
                        }
                        else
                        {
                            var shop = new Shop();
                            Rooms[i, j] = new Room(RoomType.Shop, shop: shop);
                        }
                    }
                }
            }
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Enter command (move, fight, shop, stats, exit):");
                string command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "move":
                        MovePlayer();
                        break;
                    case "fight":
                        FightCurrentEnemy();
                        break;
                    case "shop":
                        VisitCurrentShop();
                        break;
                    case "stats":
                        DisplayStats();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }

        private void MovePlayer()
        {
            Console.WriteLine("Enter direction (north(W), south(S), east(A), west(D)):");
            string direction = Console.ReadLine().ToLower();
            switch (direction)
            {
                case "W":
                    Player.Move(Direction.North);
                    break;
                case "S":
                    Player.Move(Direction.South);
                    break;
                case "A":
                    Player.Move(Direction.East);
                    break;
                case "D":
                    Player.Move(Direction.West);
                    break;
                default:
                    Console.WriteLine("Invalid direction.");
                    break;
            }
            Console.WriteLine($"Player position: ({Player.X}, {Player.Y})");

            Room currentRoom = Rooms[Player.X, Player.Y];
            switch (currentRoom.RoomType)
            {
                case RoomType.Empty:
                    Console.WriteLine("The room is empty.");
                    break;
                case RoomType.Enemy:
                    Console.WriteLine($"You encounter an enemy: {currentRoom.Enemy.Name}");
                    Console.WriteLine($"Enemy stats - Strength: {currentRoom.Enemy.Strength}, Health: {currentRoom.Enemy.Health}, Damage: {currentRoom.Enemy.Damage}");
                    Console.WriteLine("Do you want to fight? (yes/no)");
                    string fightChoice = Console.ReadLine().ToLower();
                    if (fightChoice == "yes")
                    {
                        Fight(currentRoom.Enemy);
                    }
                    break;
                case RoomType.Treasure:
                    Console.WriteLine($"You found a treasure with {currentRoom.Treasure} gold!");
                    Player.Money += currentRoom.Treasure;
                    currentRoom.RoomType = RoomType.Empty; // Remove treasure from room
                    break;
                case RoomType.Boss:
                    Console.WriteLine($"You encounter a boss: {currentRoom.Enemy.Name}");
                    Console.WriteLine($"Boss stats - Strength: {currentRoom.Enemy.Strength}, Health: {currentRoom.Enemy.Health}, Damage: {currentRoom.Enemy.Damage}");
                    Console.WriteLine("Do you want to fight the boss? (yes/no)");
                    string bossFightChoice = Console.ReadLine().ToLower();
                    if (bossFightChoice == "yes")
                    {
                        Fight(currentRoom.Enemy);
                    }
                    break;
                case RoomType.Shop:
                    Console.WriteLine("You found a shop. Do you want to visit it? (yes/no)");
                    string shopChoice = Console.ReadLine().ToLower();
                    if (shopChoice == "yes")
                    {
                        VisitShop(currentRoom.Shop);
                    }
                    break;
            }
        }

        private void DisplayStats()
        {
            Console.WriteLine($"Name: {Player.Name}");
            Console.WriteLine($"Race: {Player.PlayerRace}");
            Console.WriteLine($"Profession: {Player.PlayerProfession}");
            Console.WriteLine($"Strength: {Player.Strength}");
            Console.WriteLine($"Health: {Player.Health}");
            Console.WriteLine($"Critical Chance: {Player.CriticalChance}");
            Console.WriteLine($"Damage: {Player.Damage}");
            Console.WriteLine($"Experience: {Player.Experience}");
            Console.WriteLine($"Level: {Player.Level}");
            Console.WriteLine($"Money: {Player.Money}");
        }

        private void Fight(Enemy enemy)
        {
            while (Player.Health > 0 && enemy.Health > 0)
            {
                int playerDamage = Player.Damage;
                if (new Random().NextDouble() < Player.CriticalChance)
                {
                    playerDamage *= 2;
                    Console.WriteLine("Critical hit!");
                }

                enemy.Health -= playerDamage;
                Console.WriteLine($"You hit the enemy for {playerDamage} damage. Enemy health: {enemy.Health}");

                if (enemy.Health <= 0)
                {
                    Console.WriteLine("You defeated the enemy!");
                    Player.GainExperience(100); // Arbitrary XP for defeating an enemy
                    return;
                }

                int enemyDamage = enemy.Damage;
                Player.Health -= enemyDamage;
                Console.WriteLine($"The enemy hits you for {enemyDamage} damage. Your health: {Player.Health}");

                if (Player.Health <= 0)
                {
                    Console.WriteLine("You have been defeated!");
                    return;
                }
            }
        }

        private void VisitShop(Shop shop)
        {
            while (true)
            {
                shop.DisplayItems();
                Console.WriteLine("Enter the item number to purchase it, or 'exit' to leave the shop.");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }
                if (int.TryParse(input, out int itemNumber))
                {
                    if (!shop.BuyItem(Player, itemNumber))
                    {
                        Console.WriteLine("You don't have enough money or invalid item number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }

        private void FightCurrentEnemy()
        {
            Room currentRoom = Rooms[Player.X, Player.Y];
            if (currentRoom.RoomType == RoomType.Enemy || currentRoom.RoomType == RoomType.Boss)
            {
                Fight(currentRoom.Enemy);
            }
            else
            {
                Console.WriteLine("There's no enemy here.");
            }
        }

        private void VisitCurrentShop()
        {
            Room currentRoom = Rooms[Player.X, Player.Y];
            if (currentRoom.RoomType == RoomType.Shop)
            {
                VisitShop(currentRoom.Shop);
            }
            else
            {
                Console.WriteLine("There's no shop here.");
            }
        }
    }
}

public enum RoomType
{
    Empty,
    Enemy,
    Treasure,
    Boss,
    Shop
}

public enum Direction
{
    North,
    South,
    East,
    West
}