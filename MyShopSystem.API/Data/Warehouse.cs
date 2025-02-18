using System.ComponentModel.DataAnnotations;

namespace MyShopSystem.API.Data
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public ICollection<WarehouseProduct> WarehouseProducts { get; set; } = new List<WarehouseProduct>();
    }
}
