using Commons.Models.OrderDetailDTO;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface IOrderDetailsService
    {
        Task<List<GetOrderDetailListDTO>> GetAllOrderDetails();
        Task<GetOrderDetailDTO> GetOrderDetail(int Id);
        Task<GetOrderDetailDTO> CreateOrderDetail(CreateOrderDetailDTO createOrderDetail);
        Task UpdateOrderDetail(GetOrderDetailDTO updateorderDetail);
        Task DeleteOrderDetail(int Id);
    }
}
