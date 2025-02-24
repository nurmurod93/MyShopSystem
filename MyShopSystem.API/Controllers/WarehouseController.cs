using Commons.Models.WarehouseDTO;
using Microsoft.AspNetCore.Mvc;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Controllers
{
    public class WarehouseController(IWarehouceService warehouceService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<GetWarehouseListDTO>>> GetAllWarehouse()
        {
            var warehouses = await warehouceService.GetAllWarehouse();
            return Ok(warehouses);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetWarehouseDTO>> GetWarehouse(int Id)
        {
            var warehouse = await warehouceService.GetWarehouse(Id);
            if(warehouse == null)
            {
                return NotFound();
            }
            return Ok(warehouse);
        }
        [HttpPost]
        public async Task<ActionResult<GetWarehouseDTO>> CreateWarehouse([FromBody] CreateWarehouseDTO createWarehouse)
        {
            var newWarehouse = await warehouceService.CreateWarehouse(createWarehouse);
            return Ok(newWarehouse);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateWarehouse(GetWarehouseDTO updateWarehouse)
        {
            await warehouceService.UpdateWarehouse(updateWarehouse);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteWarehouse(int Id)
        {
            await warehouceService.DeleteWarehouse(Id);
            return NoContent();
        }
    }
}
