using Commons.Models.StoreDTO;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface IStoreService
    {
        Task<List<GetStoreListDTO>> GetAllStore();
        Task<GetStoreDTO> GetStore(int Id);
        Task<GetStoreDTO> CreateStore(CreateStoreDTO createStore);
        Task UpdateStore(GetStoreDTO updaeStore);
        Task DeleteStore(int Id);
    }
}
