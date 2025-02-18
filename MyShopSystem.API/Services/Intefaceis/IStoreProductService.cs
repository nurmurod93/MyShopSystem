using Commons.Models.StoreProductDTO;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface IStoreProductService
    {
        Task<List<GetStoreProductListDTO>> GeyAllStoreProduct();
        Task<GetStoreProductDTO> GetStoreProduct(int Id);
        Task<GetStoreProductDTO> CreateStoreProduct(CreateStoreProductDTO createStoreProduct);
        Task UpdateStoreProduct(GetStoreProductDTO updateStoreProduct);
        Task DeleteStoreProduct(int Id);
    }
}
