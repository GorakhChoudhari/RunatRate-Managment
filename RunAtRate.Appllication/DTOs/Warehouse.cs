
namespace RunAtRate.Appllication.DTOs
{
    public  class Warehouse
    {
        public int WarehouseID { get; set; }                // PK
        public string WarehouseName { get; set; } = string.Empty;
        public string? Location { get; set; }

        // Navigation
        public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    }
}
