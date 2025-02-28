namespace MyShopSystem.API.Data
{
    public class Receive
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Supplier { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public decimal Price { get; set; } 
        public DateTime ReceivedDate { get; set; }
    }
}
