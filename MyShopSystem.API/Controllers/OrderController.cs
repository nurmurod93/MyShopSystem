using Commons.Models.OrderDTO;
using Microsoft.AspNetCore.Mvc;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetOrderListDTO>> GetAllOrder()
        {
            var orders = await orderService.GetAllOrder();
            return Ok(orders);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetOrderDTO>> GetOrder(int Id)
        {
            var order = await orderService.GetOrder(Id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPost]
        public async Task<ActionResult<GetOrderDTO>> CreateOrder([FromBody] CreateOrderDTO createOrder)
        {
            var newOrder = await orderService.CreateOrder(createOrder);
            return Ok(newOrder);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateOrder(GetOrderDTO updateOrder)
        {
            await orderService.UpdateOrder(updateOrder);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteOrder(int Id)
        {
            await orderService.DeleteOrder(Id);
            return NoContent();
        }
    }
}
