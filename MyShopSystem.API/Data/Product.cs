﻿using System.ComponentModel.DataAnnotations;

namespace MyShopSystem.API.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ICollection<WarehouseProduct> WarehouseProducts { get; set; } = new List<WarehouseProduct>();
        public ICollection<StoreProduct> StoreProducts { get; set; } = new List<StoreProduct>();
    }
}
