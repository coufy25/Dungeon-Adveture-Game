namespace Zaverecny__projekt_PV
{
    public class Room
{
    public RoomType RoomType { get; set; }
    public Enemy Enemy { get; set; }
    public int Treasure { get; set; }
    public Shop Shop { get; set; }
    public object Extra { get; set; }

    public Room(RoomType roomType, Enemy enemy = null, int treasure = 0, Shop shop = null)
    {
        RoomType = roomType;
        Enemy = enemy;
        Treasure = treasure;
        Shop = shop;
        Extra = enemy ?? (object)shop ?? treasure;
    }
}

}