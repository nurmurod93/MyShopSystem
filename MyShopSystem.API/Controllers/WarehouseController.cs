using Commons.Models.WarehouseDTO;
using Microsoft.AspNetCore.Mvc;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Controllers
{
    [ApiController]
    [Route("Api[controller]/[action]")]
    public class WarehouseController(IWarehouceService warehouseService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetWarehouseListDTO>>> GetAllWarehouse()
        {
            var warehouses = await warehouseService.GetAllWarehouse();
            return Ok(warehouses);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetWarehouseDTO>> GetWarehouse(int Id)
        {
            var warehouse = await warehouseService.GetWarehouse(Id);
            if(warehouse == null)
            {
                return NotFound();
            }
            return Ok(warehouse);
        }
        [HttpPost]
        public async Task<ActionResult<GetWarehouseDTO>> CreateWarehouse([FromBody] CreateWarehouseDTO createWarehouse)
        {
            var newWarehouse = await warehouseService.CreateWarehouse(createWarehouse);
            return Ok(newWarehouse);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateWarehouse(GetWarehouseDTO updateWarehouse)
        {
            await warehouseService.UpdateWarehouse(updateWarehouse);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteWarehouse(int Id)
        {
            await warehouseService.DeleteWarehouse(Id);
            return NoContent();
        }
    }
}
