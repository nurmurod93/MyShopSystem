using Commons.Models.BranchDTO;
using Microsoft.AspNetCore.Mvc;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Controllers
{
    
    public class BranchController(IBranchService branchService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<GetBranchListDTO>>> GetAllBranch()
        {
            var branches = await branchService.GetAllBranch();
            return Ok(branches);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetBranchDTO>> GetBranch(int Id)
        {
            var branch = await branchService.GetBranch(Id);
            if(branch == null)
            {
                return NotFound();
            }
            return Ok(branch);
        }
        [HttpPost]
        public async Task<ActionResult<GetBranchDTO>> AddBranch([FromBody] CreateBranchDTO createBranch)
        {
            var newBranch = await branchService.CreateBranch(createBranch);
            return Ok(newBranch);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateBranch([FromBody] GetBranchDTO getBranch)
        {
            await branchService.UpdateBranch(getBranch);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteBranch(int Id)
        {
            await branchService.DeleteBranch(Id);
            return NoContent();
        }
    }
}
