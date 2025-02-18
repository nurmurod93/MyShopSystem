using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models.DeliveryDTO
{
    public class GetDeliveryListDTO
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int StoreId { get; set; }
        public DateTime DeliveryDate { get; set; }


    }
}
