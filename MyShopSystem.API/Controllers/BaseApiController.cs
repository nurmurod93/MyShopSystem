using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyShopSystem.API.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    [Authorize]
    public class BaseApiController:ControllerBase
    {
    }
}
