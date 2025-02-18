using Commons.Models.CompanyDTO;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface ICompanyService
    {
        Task<List<GetCompanyListDTO>> GetAllCompany();
        Task<GetCompanyDTO> GetCompany(int Id);
        Task<GetCompanyDTO> CreateCompany(CreateCompanyDTO company);
        Task UpdateCompany(GetCompanyDTO company);
        Task DeleteCompany(int Id);
    }
}
