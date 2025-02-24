using System.ComponentModel.DataAnnotations;

namespace MyShopSystem.API.Data
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Branch> Branches { get; set; } = new List<Branch>();
        public ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
    }
}

