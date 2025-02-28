using Commons.Models.Receive;

namespace MyShopSystem_UI.Service
{
    public interface IReceiveService
    {
        public Task<List<GetReceiveListDTO>> GetAllReceive();
        public Task<GetReceiveDTO> GetReceiveById(int Id);
        public Task<GetReceiveDTO> CreateReceive(CreateReceiveDTO createReceive);
        public Task UpdateReceive(GetReceiveDTO updateReceive);
        public Task DeleteReceiveById(int Id);
    }
    public class ReceiveService(IConfiguration configuration) : IReceiveService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string _baseUrl = configuration["BackendUrl"] + "/receive";
        public async Task<GetReceiveDTO> CreateReceive(CreateReceiveDTO createReceive)
        {
            var response = await client.PostAsJsonAsync(_baseUrl + "/CreateReceive", createReceive);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetReceiveDTO>();
        }

        public async Task DeleteReceiveById(int Id)
        {
            var response = await client.DeleteAsync($"{_baseUrl}/DeleteReceive/{Id}");
            response.EnsureSuccessStatusCode();

        }

        public async Task<List<GetReceiveListDTO>> GetAllReceive()
        {
            var response = await client.GetAsync(_baseUrl + "/GetAllReceive");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List < GetReceiveListDTO >> ();
            return data;
        }

        public async Task<GetReceiveDTO> GetReceiveById(int Id)
        {
            var response = await client.GetAsync($"{_baseUrl}/GetReceiveById/{Id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetReceiveDTO>();
        }

        public async Task UpdateReceive(GetReceiveDTO updateReceive)
        {
            var response = await client.PutAsJsonAsync($"{_baseUrl}/UpdateReceive", updateReceive);
            response.EnsureSuccessStatusCode();
        }
    }
}
