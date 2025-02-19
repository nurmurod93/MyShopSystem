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
            var responce = await client.PostAsJsonAsync(_baseUrl + "/AddStore", createStore);
            responce.EnsureSuccessStatusCode();
            return await responce.Content.ReadFromJsonAsync<GetStoreDTO>();
        }

        public async Task DeleteStore(int Id)
        {
            var responce = await client.DeleteAsync($"{_baseUrl}/DeleteStore/{Id}");
            responce.EnsureSuccessStatusCode();
        }

        public async Task<List<GetStoreListDTO>> GetAllStore()
        {
            var responce = await client.GetAsync(_baseUrl + "/GetAllStore");
            responce.EnsureSuccessStatusCode();
            var data = await responce.Content.ReadFromJsonAsync<List<GetStoreListDTO>>();
            return data;
        }

        public async Task<GetStoreDTO> GetStore(int Id)
        {
            var responce = await client.GetAsync($"{_baseUrl}/GetStore/{Id}");
            responce.EnsureSuccessStatusCode();
            return await responce.Content.ReadFromJsonAsync<GetStoreDTO>();
        }

        public async Task UpdateStore(GetStoreDTO updateStore)
        {
            var responce = await client.PutAsJsonAsync($"{_baseUrl}/UpdateStore", updateStore);
            responce.EnsureSuccessStatusCode();
        }
    }
}
