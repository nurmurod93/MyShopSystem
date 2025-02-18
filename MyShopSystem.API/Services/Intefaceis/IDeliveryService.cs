using Commons.Models.DeliveryDTO;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface IDeliveryService
    {
        Task<List<GetDeliveryListDTO>> GetAllDelivery();
        Task<GetDeliveryDTO> GetDelivery(int Id);
        Task<GetDeliveryDTO> CreateDelivery(CreateDeliveryDTO delivery);
        Task UpdateDelivery(GetDeliveryDTO updateDelivery);
        Task DeleteDelivery(int Id);
    }
}
