using Commons.Models.OrderDTO;

namespace MyShopSystem_UI.Service
{
    public interface IOrderService
    {
        public Task<List<GetOrderListDTO>> GetAllOrder();
        public Task<GetOrderDTO> GetOrder(int Id);
        public Task<GetOrderDTO> CreateOrder(CreateOrderDTO createOrder);
        public Task UpdateOrder(GetOrderDTO updateOrder);
        public Task DeleteOrder(int Id);
    }
    public class OrderService(IConfiguration configuration) : IOrderService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string _baseUrl = configuration["BackendUrl"] + "/order";
        public async Task<GetOrderDTO> CreateOrder(CreateOrderDTO createOrder)
        {
            var response = await client.PostAsJsonAsync(_baseUrl + "/CreateOrder", createOrder);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetOrderDTO>();
        }

        public async Task DeleteOrder(int Id)
        {
            var response = await client.DeleteAsync($"{_baseUrl}/DeleteOrder/{Id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetOrderListDTO>> GetAllOrder()
        {
            var response = await client.GetAsync(_baseUrl + "/GetAllOrder");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<GetOrderListDTO>>();
            return data;
        }

        public async Task<GetOrderDTO> GetOrder(int Id)
        {
            var response = await client.GetAsync($"{_baseUrl}/GetOrder/{Id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetOrderDTO>();
        }

        public async Task UpdateOrder(GetOrderDTO updateOrder)
        {
            var response = await client.PutAsJsonAsync($"{_baseUrl}/UpdateOrder", updateOrder);
            response.EnsureSuccessStatusCode();
        }
    }
}
