using Commons.Models.Send;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface ISendService
    {
        Task<List<GetSendListDTO>> GetAllSend();
        Task<GetSendDTO> GetSend(int Id);
        Task<GetSendDTO> CreateSend(CreateSendDTO createSend);
        Task UpdateSend(GetSendDTO updateSend);
        Task DeleteSend(int Id);
    }
}
