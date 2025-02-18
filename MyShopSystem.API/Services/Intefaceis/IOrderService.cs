using Commons.Models.OrderDTO;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface IOrderService
    {
        Task<List<GetOrderListDTO>> GetAllOrder();
        Task<GetOrderDTO> GetOrder(int id);
        Task<GetOrderDTO> CreateOrder(CreateOrderDTO order);
        Task UpdateOrder(GetOrderDTO updateorder);
        Task DeleteOrder(int Id);
    }
}
