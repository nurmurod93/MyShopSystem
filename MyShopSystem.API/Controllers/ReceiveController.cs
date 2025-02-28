using Commons.Models.Receive;
using Microsoft.AspNetCore.Mvc;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Controllers
{
    public class ReceiveController(IReceivesService receivesService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<GetReceiveListDTO>>> GetAllReceive()
        {
            var receive = await receivesService.GetAllReceive();
            return Ok(receive);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetReceiveDTO>> GetReceiveById(int Id)
        {
            var receive = await receivesService.GetReceiveById(Id);
            if (receive == null)
            {
                return NotFound();
            }
            return Ok(receive);
        }
        [HttpPost]
        public async Task<ActionResult<GetReceiveDTO>> CreateReceive(CreateReceiveDTO createReceive)
        {
            var newReceive = await receivesService.CreateReceive(createReceive);
            return Ok(newReceive);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateReceive([FromBody] GetReceiveDTO updatereceive)
        {
            await receivesService.UpdateReceive(updatereceive);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteReceive(int Id)
        {
            await receivesService.DeleteReceiveById(Id);
            return NoContent();
        }
    }
}
