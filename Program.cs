using System;

namespace Zaverecny__projekt_PV
{
    // Třída Program je vstupním bodem aplikace.
    class Program
    {
        // Metoda Main je vstupním bodem programu, která se spouští jako první.
        public static void Main(string[] args)
        {
            // Výpis uvítací zprávy.
            Console.WriteLine("Welcome to the Dungeon Game!");
            // Požádání uživatele o zadání jména postavy.
            Console.WriteLine("Enter your character's name:");
            // Přečtení zadaného jména postavy od uživatele.
            string playerName = Console.ReadLine();

            // Výběr rasy postavy.
            Console.WriteLine("Choose your race: 1. Human, 2. Elf, 3. Dwarf, 4. Hobbit, 5. Troll, 6. Orc");
            // Proměnná pro uchování vybrané rasy postavy.
            Race playerRace;
            // Načtení vstupu od uživatele a rozhodnutí na základě vstupu.
            switch (Console.ReadLine())
            {
                // Pokud uživatel vybral číslo 1, nastaví se postava jako Human.
                case "1":
                    playerRace = Race.Human;
                    break;
                // Pokud uživatel vybral číslo 2, nastaví se postava jako Elf.
                case "2":
                    playerRace = Race.Elf;
                    break;
                // Pokud uživatel vybral číslo 3, nastaví se postava jako Dwarf.
                case "3":
                    playerRace = Race.Dwarf;
                    break;
                // Pokud uživatel vybral číslo 4, nastaví se postava jako Hobbit.
                case "4":
                    playerRace = Race.Hobbit;
                    break;
                // Pokud uživatel vybral číslo 5, nastaví se postava jako Troll.
                case "5":
                    playerRace = Race.Troll;
                    break;
                // Pokud uživatel vybral číslo 6, nastaví se postava jako Orc.
                case "6":
                    playerRace = Race.Orc;
                    break;
                // V případě neplatné volby se postava nastaví jako Human.
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Human.");
                    playerRace = Race.Human;
                    break;
            }

            // Výběr profese postavy.
            Console.WriteLine("Choose your profession: 1. Warrior, 2. Thief, 3. Mage, 4. Priest");
            // Proměnná pro uchování vybrané profese postavy.
            Profession playerProfession = null;
            // Načtení vstupu od uživatele a rozhodnutí na základě vstupu.
            switch (Console.ReadLine())
            {
                // Pokud uživatel vybral číslo 1, nastaví se profese jako Warrior.
                case "1":
                    playerProfession = new Profession("Warrior", 5, 100, 0.1, 10);
                    break;
                // Pokud uživatel vybral číslo 2, nastaví se profese jako Thief.
                case "2":
                    playerProfession = new Profession("Thief", 4, 80, 0.2, 8);
                    break;
                // Pokud uživatel vybral číslo 3, nastaví se profese jako Mage.
                case "3":
                    playerProfession = new Profession("Mage", 3, 60, 0.3, 6);
                    break;
                // Pokud uživatel vybral číslo 4, nastaví se profese jako Priest.
                case "4":
                    playerProfession = new Profession("Priest", 4, 70, 0.15, 7);
                    break;
                // V případě neplatné volby se profese nastaví jako Warrior.
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Warrior.");
                    playerProfession = new Profession("Warrior", 5, 100, 0.1, 10);
                    break;
            }

            // Vytvoření instance hry s nastaveným jménem postavy, rasou a profesí, na pozici 0,0.
            Game game = new Game(playerName, playerRace, playerProfession, 0, 0);
            // Spuštění hry.
            game.Start();
        }
    }
}
