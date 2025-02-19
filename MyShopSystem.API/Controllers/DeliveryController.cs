using Commons.Models.DeliveryDTO;
using Microsoft.AspNetCore.Mvc;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Controllers
{
    [ApiController]
    [Route("Api[controller]/[action]")]
    public class DeliveryController(IDeliveryService deliveryService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetDeliveryListDTO>> GetAllDelivery()
        {
            var deliveryies = await deliveryService.GetAllDelivery();
            return Ok(deliveryies);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetDeliveryDTO>> GetDelivery(int Id)
        {
            var delivery = await deliveryService.GetDelivery(Id);
            if(delivery == null)
            {
                return NotFound();
            }
            return Ok(delivery);
        }
        [HttpPost]
        public async Task<ActionResult<GetDeliveryDTO>> CreateDelivery([FromBody] CreateDeliveryDTO createDelivery)
        {
            var newDelivery = await deliveryService.CreateDelivery(createDelivery);
            return Ok(newDelivery);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateDelivery([FromBody] GetDeliveryDTO updateDelivvery)
        {
            await deliveryService.UpdateDelivery(updateDelivvery);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteDelivery(int Id)
        {
            await deliveryService.DeleteDelivery(Id);
            return NoContent();
        }
    }
}
