using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models.OrderDTO
{
    public class CreateOrderDTO
    {
        [Key]
        public int Id { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderDate { get; set; }
      
    }
}
