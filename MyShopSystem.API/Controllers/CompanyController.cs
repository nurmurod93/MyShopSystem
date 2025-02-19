using Commons.Models.CompanyDTO;
using Microsoft.AspNetCore.Mvc;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Controllers
{
    [ApiController]
    [Route("Api[controller]/[action]")]
    public class CompanyController(ICompanyService companyService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetCompanyListDTO>>> GetAllCompany()
        {
            var companyies = await companyService.GetAllCompany();
            return Ok(companyies);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetCompanyDTO>> GetCompany(int Id)
        {
            var company = await companyService.GetCompany(Id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
        [HttpPost]
        public async Task<ActionResult<GetCompanyDTO>> AddCompany([FromBody] CreateCompanyDTO createCompany)
        {
            var newCompany = await companyService.CreateCompany(createCompany);
            return Ok(newCompany);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCompany([FromBody] GetCompanyDTO updateCompany)
        {
            await companyService.UpdateCompany(updateCompany);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCompany(int Id)
        {
            await companyService.DeleteCompany(Id);
            return NoContent();
        }
    }
}
