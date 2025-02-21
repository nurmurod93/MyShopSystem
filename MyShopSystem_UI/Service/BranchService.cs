using Commons.Models.BranchDTO;

namespace MyShopSystem_UI.Service
{
    public interface IBranchService
    {
        public Task<List<GetBranchListDTO>> GetAllBranch();
        public Task<GetBranchDTO> GetBranch(int Id);
        public Task<GetBranchDTO> CreateBranch(CreateBranchDTO createBranch);
        public Task UpdateBranch(GetBranchDTO updateBranch);
        public Task DeleteBranch(int Id);
    }
    public class BranchService(IConfiguration configuration) : IBranchService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string _baseUrl = configuration["BackendUrl"] + "/branch";
        public async Task<GetBranchDTO> CreateBranch(CreateBranchDTO createBranch)
        {
            var response = await client.PostAsJsonAsync(_baseUrl + "/CreateBranch", createBranch);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetBranchDTO>();
        }

        public async Task DeleteBranch(int Id)
        {
            var responce = await client.DeleteAsync($"{_baseUrl}/DeleteBranch/{Id}");
            responce.EnsureSuccessStatusCode();
        }

        public async Task<List<GetBranchListDTO>> GetAllBranch()
        {
            var response = await client.GetAsync(_baseUrl + "/GetAllBranch");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<GetBranchListDTO>>();
            return data;
        }

        public async Task<GetBranchDTO> GetBranch(int Id)
        {
            var response = await client.GetAsync($"{_baseUrl}/GetBranch/{Id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetBranchDTO>();
        }

        public async Task UpdateBranch(GetBranchDTO updateBranch)
        {
            var response = await client.PutAsJsonAsync($"{_baseUrl}/UpdateBranch", updateBranch);
            response.EnsureSuccessStatusCode();
        }
    }
}
