using Commons.Models.DeliveryDetailDTO;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface IDeliveryDetailsService
    {
        Task<List<GetDeliveryDetailListDTO>> GetAllDeliveryDetails();
        Task<GetDeliveryDetailDTO> GetDeliveryDetatails(int Id);
        Task<GetDeliveryDetailDTO> CreateDeliveryDetails(CreateDeliveryDetailDTO deliveryDetail);
        Task UpdateDeliveryDetails(GetDeliveryDetailDTO updateDeDt);
        Task DeleteDeliveryDetails(int Id);
    }
}
