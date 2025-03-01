using Commons.Models.Send;

namespace MyShopSystem_UI.Service
{

    public interface ISendService
    {
        public Task<List<GetSendListDTO>> GetAllSend();
        public Task<GetSendDTO> GetSendById(int Id);
        public Task<GetSendDTO> CreateSend(CreateSendDTO createSend);
        public Task UpdateSend(GetSendDTO updateSend);
        public Task DeleteSend(int Id);
    }

    public class SendService(IConfiguration configuration) : ISendService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string _baseUrl = configuration["BackendUrl"] + "/send";
        public async Task<GetSendDTO> CreateSend(CreateSendDTO createSend)
        {
            var response = await client.PostAsJsonAsync(_baseUrl + "/CreateSend", createSend);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetSendDTO>();
        }

        public async Task DeleteSend(int Id)
        {
            var response = await client.DeleteAsync($"{_baseUrl}/DeleteSend/{Id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetSendListDTO>> GetAllSend()
        {
            var response = await client.GetAsync(_baseUrl + "/GetAllSend");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<GetSendListDTO>>();
            return data;
        }

        public async Task<GetSendDTO> GetSendById(int Id)
        {
            var response = await client.GetAsync($"{_baseUrl}/GetSendById/{Id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetSendDTO>();
        }

        public async Task UpdateSend(GetSendDTO updateSend)
        {
            var response = await client.PutAsJsonAsync($"{_baseUrl}/UpdateSend", updateSend);
            response.EnsureSuccessStatusCode();
        }
    }
}
