using Commons.Models.DeliveryDTO;

namespace MyShopSystem_UI.Service
{
    public interface IDeliveryServise
    {
        public Task<List<GetDeliveryListDTO>> GetAllDelivery();
        public Task<GetDeliveryDTO> GetDeliveryById(int Id);
        public Task<GetDeliveryDTO> CreateDelivery(CreateDeliveryDTO createDelivery);
        public Task UpdateDelivery(GetDeliveryDTO updateDelivery);
        public Task DeleteDelivery(int Id);
    }

    public class DeliveryService(IConfiguration configuration) : IDeliveryServise
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string _baseUrl = configuration["BackendUrl"] + "/delivery";
        public async Task<GetDeliveryDTO> CreateDelivery(CreateDeliveryDTO createDelivery)
        {
            var response = await client.PostAsJsonAsync(_baseUrl + "/CreateDelivery", createDelivery);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetDeliveryDTO>();
        }

        public async Task DeleteDelivery(int Id)
        {
            var response = await client.DeleteAsync($"{_baseUrl}/DeleteDelevery/{Id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetDeliveryListDTO>> GetAllDelivery()
        {
            var response = await client.GetAsync(_baseUrl + "/GetAllDelivery");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<GetDeliveryListDTO>>();
            return data;
        }

        public async Task<GetDeliveryDTO> GetDeliveryById(int Id)
        {
            var response = await client.GetAsync($"{_baseUrl}/GetDelivery/{Id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetDeliveryDTO>();
        }

        public async Task UpdateDelivery(GetDeliveryDTO updateDelivery)
        {
            var response = await client.PutAsJsonAsync($"{_baseUrl}/UpdateDelivery", updateDelivery);
            response.EnsureSuccessStatusCode();
        }
    }
}
