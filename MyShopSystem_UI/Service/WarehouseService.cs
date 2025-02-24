using Commons.Models.WarehouseDTO;

namespace MyShopSystem_UI.Service
{
    public interface IWarehouseService
    {
        public Task<List<GetWarehouseListDTO>> GetAllWarehouse();
        public Task<GetWarehouseDTO> GetWarehouse(int Id);
        public Task<GetWarehouseDTO> CreateWarehouse(CreateWarehouseDTO createWarehouse);
        public Task UpdateWarehouse(GetWarehouseDTO updateWarehouse);
        public Task DeleteWarehouse(int Id);
    }
    public class WarehouseService(IConfiguration configuration) : IWarehouseService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string _baseUrl = configuration["BackendUrl"] + "/warehouse";
        public async Task<GetWarehouseDTO> CreateWarehouse(CreateWarehouseDTO createWarehouse)
        {
            var response = await client.PostAsJsonAsync(_baseUrl + "/CreateWarehouse", createWarehouse);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetWarehouseDTO>();
        }

        public async Task DeleteWarehouse(int Id)
        {

            var response = await client.DeleteAsync($"{_baseUrl}/DeleteWarehouse/{Id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetWarehouseListDTO>> GetAllWarehouse()
        {
            var response = await client.GetAsync(_baseUrl + "/GetAllWarehouse");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<GetWarehouseListDTO>>();
            return data;
        }

        public async Task<GetWarehouseDTO> GetWarehouse(int Id)
        {
            var response = await client.GetAsync($"{_baseUrl}/GetWarehouse/{Id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetWarehouseDTO>();
        }

        public async Task UpdateWarehouse(GetWarehouseDTO updateWarehouse)
        {
            var response = await client.PutAsJsonAsync($"{_baseUrl}/UpdateWarehouse", updateWarehouse);
            response.EnsureSuccessStatusCode();
        }
    }
}
