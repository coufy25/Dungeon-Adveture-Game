using System;

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

public static class RaceExtensions
{
    public static RaceAttributes GetAttributes(this Race race)
    {
        switch (race)
        {
            // Pokud je rasa Human.
            case Race.Human:
                // Vrátí atributy pro Human (síla 10, zdraví 8).
                return new RaceAttributes(10, 8);
            // Pokud je rasa Elf.
            case Race.Elf:
                // Vrátí atributy pro Elfa (síla 5, zdraví 15).
                return new RaceAttributes(5, 15);
            // Pokud je rasa Dwarf.
            case Race.Dwarf:
                // Vrátí atributy pro Dwarfa (síla 15, zdraví 6).
                return new RaceAttributes(15, 6);
            // Pokud je rasa Hobbit.
            case Race.Hobbit:
                // Vrátí atributy pro Hobbita (síla 7, zdraví 10).
                return new RaceAttributes(7, 10);
            // Pokud je rasa Troll.
            case Race.Troll:
                // Vrátí atributy pro Trolla (síla 20, zdraví 5).
                return new RaceAttributes(20, 5);
            // Pokud je rasa Orc.
            case Race.Orc:
                // Vrátí atributy pro Orca (síla 18, zdraví 7).
                return new RaceAttributes(18, 7);
            // Pokud je rasa Goblin.
            case Race.Goblin:
                // Vrátí atributy pro Goblina (síla 8, zdraví 6).
                return new RaceAttributes(8, 6);
            default:
                throw new ArgumentException("Invalid race");
        }
    }
}