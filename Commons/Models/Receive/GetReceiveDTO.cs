using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models.Receive
{
    public class GetReceiveDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Supplier { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
