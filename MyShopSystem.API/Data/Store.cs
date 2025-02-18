using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyShopSystem.API.Data
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; } = null!;
        public ICollection<StoreProduct> StoreProducts { get; set; } = new List<StoreProduct>();
    }
}
