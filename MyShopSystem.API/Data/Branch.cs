using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyShopSystem.API.Data
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        // Filial qaysi kompaniyaga tegishli?
        public int CompanyId { get; set; }
        public ICollection<Warehouse> Warehouse { get; set; } = new List<Warehouse>();
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
