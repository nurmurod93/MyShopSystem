﻿using System.ComponentModel.DataAnnotations;

namespace MyShopSystem.API.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "User"; // Admin, WarehouseManager, StoreManager
    }
}
