using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyShopSystem.API.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        [ForeignKey("StoreId")]
        public Store Store { get; set; } = null!;
    }
}
