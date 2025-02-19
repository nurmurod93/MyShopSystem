using Commons.Models.UserDTO;
using Microsoft.AspNetCore.Mvc;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Controllers
{
    [ApiController]
    [Route("Api[controller]/[action]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetUserListDTO>>> GetAllUser()
        {
            var users = await userService.GetAllUser();
            return Ok(users);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetUserDTO>> GetUser(int Id)
        {
            var user = await userService.GetUser(Id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<GetUserDTO>> CreateUser([FromBody] CreateUserDTO createUser)
        {
            var newUser = await userService.CreateUser(createUser);
            return Ok(newUser);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] GetUserDTO updateUser)
        {
            await userService.UpdateUser(updateUser);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteUser(int Id)
        {
            await userService.DeleteUser(Id);
            return NoContent();
        }
    }
}
