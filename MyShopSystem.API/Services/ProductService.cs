using Commons.Models.ProductDTO;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class ProductService(ApplicationDbContext context) : IProductService
    {
        public async Task<GetProductDTO> CreateProduct(CreateProductDTO createProduct)
        {
            var newEntity = new Product()
            {
                Id = createProduct.Id,
                Name = createProduct.Name,
                Price = createProduct.Price,
            };

            var entry = await context.Products.AddAsync(newEntity);
            await context.SaveChangesAsync();

            return new GetProductDTO
            {
                Id = newEntity.Id,
                Name = newEntity.Name,
                Price = newEntity.Price,
            };
        }

        public async Task DeleteProduct(int Id)
        {
            var data = await context.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if(data != null)
            {
                context.Products.Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<GetProductListDTO>> GetAllProduct()
        {
            var data = await context.Products.Include(p => p.StoreProducts).ToListAsync();
            if(data is null && !data.Any()) return [];
            var allProduct = new List<GetProductListDTO>();
            foreach(var product in data)
            {
                allProduct.Add(new GetProductListDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                });
            }
            return allProduct;
        }

        public async Task<GetProductDTO> GetProduct(int Id)
        {
            var data = await context.Products.Include(p => p.StoreProducts).FirstOrDefaultAsync(p => p.Id == Id);
            if (data != null)
            {
                return new GetProductDTO()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Price = data.Price,
                };
            }
            else
                throw new Exception("Not found!");
        }

        public async Task UpdateProduct(GetProductDTO updateProduct)
        {
            var old = await context.Products.FirstOrDefaultAsync(p => p.Id == updateProduct.Id);
            if (old != null)
            {
                old.Name = updateProduct.Name;
                old.Price = updateProduct.Price;

                context.Products.Update(old);
                await context.SaveChangesAsync();
            }
        }
    }
}
