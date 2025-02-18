using Commons.Models.ProductDTO;

namespace MyShopSystem_UI.Service
{
    public interface IProductService
    {
        public Task<List<GetProductListDTO>> GetAllProduct();
        public Task<GetProductDTO> GetProduct(int Id);
        public Task<GetProductDTO> CreateProduct(CreateProductDTO createProduct);
        public Task UpdateProduct(GetProductDTO updateProduct);
        public Task DeleteProduct(int Id);
    }
    public class ProductService(IConfiguration configuration) : IProductService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string _baseUrl = configuration["BackendUrl"] + "/product";
        public async Task<GetProductDTO> CreateProduct(CreateProductDTO createProduct)
        {
            var responce = await client.PostAsJsonAsync(_baseUrl + "/AddProduct", createProduct);
            responce.EnsureSuccessStatusCode();
            return await responce.Content.ReadFromJsonAsync<GetProductDTO>();
        }

        public async Task DeleteProduct(int Id)
        {
            var responce = await client.DeleteAsync($"{_baseUrl}/DeleteProduct/{Id}");
            responce.EnsureSuccessStatusCode();
        }

        public async Task<List<GetProductListDTO>> GetAllProduct()
        {
            var responce = await client.GetAsync(_baseUrl + "/GetAllProduct");
            responce.EnsureSuccessStatusCode();
            var data = await responce.Content.ReadFromJsonAsync<List<GetProductListDTO>>();
            return data;
        }

        public async Task<GetProductDTO> GetProduct(int Id)
        {
            var responce = await client.GetAsync($"{_baseUrl}/GetProduct/{Id}");
            responce.EnsureSuccessStatusCode();
            return await responce.Content.ReadFromJsonAsync<GetProductDTO>();
        }

        public async Task UpdateProduct(GetProductDTO updateProduct)
        {
            var responce = await client.PutAsJsonAsync($"{_baseUrl}/UpdateProduct", updateProduct);
            responce.EnsureSuccessStatusCode();
        }
    }
}
