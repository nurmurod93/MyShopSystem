using Commons.Models.Send;
using Microsoft.AspNetCore.Mvc;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Controllers
{
    public class SendController(ISendService sendService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<GetSendListDTO>>> GetAllSend()
        {
            var send = await sendService.GetAllSend();
            return Ok(send);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetSendDTO>> GetSendById(int Id)
        {
            var send = await sendService.GetSend(Id);
            if (send == null)
            {
                return NotFound();
            }
            return Ok(send);
        }
        [HttpPost]
        public async Task<ActionResult<GetSendDTO>> CreateSend(CreateSendDTO createSend)
        {
            var newSend = await sendService.CreateSend(createSend);
            return Ok(newSend);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateSend([FromBody] GetSendDTO updateSend)
        {
            await sendService.UpdateSend(updateSend);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteSend(int Id)
        {
            await sendService.DeleteSend(Id);
            return NoContent();
        }
    }
}
