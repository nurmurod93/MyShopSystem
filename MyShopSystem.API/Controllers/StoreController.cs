using Commons.Models.StoreDTO;
using Microsoft.AspNetCore.Mvc;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Controllers
{
    public class StoreController(IStoreService storeService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<GetStoreListDTO>>> GetAllStore()
        {
            var storeall = await storeService.GetAllStore();
            return Ok(storeall);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetStoreDTO>> GetStore(int Id)
        {
            var store = await storeService.GetStore(Id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }
        [HttpPost]
        public async Task<ActionResult<GetStoreDTO>> AddStore([FromBody] CreateStoreDTO createStore)
        {
            var newStore = await storeService.CreateStore(createStore);
            return Ok(newStore);
        }
        [HttpPut]
        public async Task<ActionResult<GetStoreDTO>> UpdateStore([FromBody] GetStoreDTO getStore)
        {
            await storeService.UpdateStore(getStore);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteStore(int Id)
        {
            await storeService.DeleteStore(Id);
            return NoContent();
        }
    }
}
