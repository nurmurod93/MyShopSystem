using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShopSystem.API.Data
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }
        
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
