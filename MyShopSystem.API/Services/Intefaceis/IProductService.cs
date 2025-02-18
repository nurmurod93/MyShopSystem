using Commons.Models.ProductDTO;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface IProductService
    {
        Task<List<GetProductListDTO>> GetAllProduct();
        Task<GetProductDTO> GetProduct(int Id);
        Task<GetProductDTO> CreateProduct(CreateProductDTO createProduct);
        Task UpdateProduct(GetProductDTO updateProduct);
        Task DeleteProduct(int Id);
    }
}
