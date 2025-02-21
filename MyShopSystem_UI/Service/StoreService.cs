using Commons.Models.StoreDTO;

namespace MyShopSystem_UI.Service
{
    public interface IStoreService
    {
        public  Task<List<GetStoreListDTO>> GetAllStore();
        public Task<GetStoreDTO> GetStore(int Id);
        public Task<GetStoreDTO> CreateStore(CreateStoreDTO createStore);
        public Task UpdateStore(GetStoreDTO updateStore);
        public Task DeleteStore(int Id);
    }
    public class StoreService(IConfiguration configuration) : IStoreService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string _baseUrl = configuration["BackendUrl"] + "/store"; 
        public async Task<GetStoreDTO> CreateStore(CreateStoreDTO createStore)
        {
            var response = await client.PostAsJsonAsync(_baseUrl + "/AddStore", createStore);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetStoreDTO>();
        }

        public async Task DeleteStore(int Id)
        {
            var response = await client.DeleteAsync($"{_baseUrl}/DeleteStore/{Id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetStoreListDTO>> GetAllStore()
        {
            var response = await client.GetAsync(_baseUrl + "/GetAllStore");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<GetStoreListDTO>>();
            return data;
        }

        public async Task<GetStoreDTO> GetStore(int Id)
        {
            var response = await client.GetAsync($"{_baseUrl}/GetStore/{Id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetStoreDTO>();
        }

        public async Task UpdateStore(GetStoreDTO updateStore)
        {
            var response = await client.PutAsJsonAsync($"{_baseUrl}/UpdateStore", updateStore);
            response.EnsureSuccessStatusCode();
        }
    }
}
