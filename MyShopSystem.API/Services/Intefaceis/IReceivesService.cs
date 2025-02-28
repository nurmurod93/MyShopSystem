using Commons.Models.Receive;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface IReceivesService
    {
        Task<List<GetReceiveListDTO>> GetAllReceive();
        Task <GetReceiveDTO> GetReceiveById(int Id);
        Task<GetReceiveDTO> CreateReceive(CreateReceiveDTO createReceive);
        Task UpdateReceive(GetReceiveDTO updateReceive);
        Task DeleteReceiveById(int Id);
    }
}
