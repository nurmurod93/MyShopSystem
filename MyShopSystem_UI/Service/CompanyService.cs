using Commons.Models.CompanyDTO;
using Commons.Models.ProductDTO;

namespace MyShopSystem_UI.Service
{
    public interface ICompanyService
    {
        public Task<List<GetCompanyListDTO>> GetAllCompany();
        public Task<GetCompanyDTO> GetCompanyById(int Id);
        public Task<GetCompanyDTO> CreateCompany(CreateCompanyDTO createCompany);
        public Task UpdateCompany(GetCompanyDTO updateCompany);
        public Task DeleteCompany(int Id);
    }
    public class CompanyService(IConfiguration configuration) : ICompanyService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string _baseUrl = configuration["BackendUrl"] + "/company";
        public async Task<GetCompanyDTO> CreateCompany(CreateCompanyDTO createCompany)
        {
            var response = await client.PostAsJsonAsync(_baseUrl + "/CreateCompany", createCompany);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetCompanyDTO>();
        }

        public async Task DeleteCompany(int Id)
        {
            var response = await client.DeleteAsync($"{_baseUrl}/DeleteCompany/{Id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetCompanyListDTO>> GetAllCompany()
        {
            var response = await client.GetAsync(_baseUrl + "/GetAllCompany");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<GetCompanyListDTO>>();
            return data;
        }

        public async Task<GetCompanyDTO> GetCompanyById(int Id)
        {
            var response = await client.GetAsync($"{_baseUrl}/GetCompany/{Id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetCompanyDTO>();
        }

        public async Task UpdateCompany(GetCompanyDTO updateCompany)
        {
            var response = await client.PutAsJsonAsync($"{_baseUrl}/UpdateCompany", updateCompany);
            response.EnsureSuccessStatusCode();
        }
    }
}
