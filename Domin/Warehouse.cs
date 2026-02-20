namespace InventopryWEB2026.Domin
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Shelf> Shelves { get; set; } = new List<Shelf>();
    }
}
