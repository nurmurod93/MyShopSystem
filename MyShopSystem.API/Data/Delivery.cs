using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyShopSystem.API.Data
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int StoreId { get; set; }
        public DateTime DeliveryDate { get; set; }

        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; } = null!;

        [ForeignKey("StoreId")]
        public Store Store { get; set; } = null!;
        public ICollection<DeliveryDetail> DeliveryDetails { get; set; } = new List<DeliveryDetail>();
    }
}
