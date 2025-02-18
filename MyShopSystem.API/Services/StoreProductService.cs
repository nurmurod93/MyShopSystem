using Commons.Models.StoreProductDTO;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class StoreProductService(ApplicationDbContext context) : IStoreProductService
    {
        public async Task<GetStoreProductDTO> CreateStoreProduct(CreateStoreProductDTO createStoreProduct)
        {
            var newEntity = new StoreProduct()
            {
                Id = createStoreProduct.Id,
                StoreId = createStoreProduct.StoreId,
                ProductId = createStoreProduct.ProductId,
                Quantity = createStoreProduct.Quantity,
            };

            var entry = await context.StoreProducts.AddAsync(newEntity);
            await context.SaveChangesAsync();

            return new GetStoreProductDTO
            {
                Id = newEntity.Id,
                StoreId = newEntity.StoreId,
                ProductId = newEntity.ProductId,
                Quantity = newEntity.Quantity,
            };
        }

        public async Task DeleteStoreProduct(int Id)
        {
            var data = await context.StoreProducts.FirstOrDefaultAsync(s => s.Id == Id);
            if(data != null)
            {
                context.StoreProducts.Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public async Task<GetStoreProductDTO> GetStoreProduct(int Id)
        {
            var data = await context.StoreProducts.Include(s => s.Store).FirstOrDefaultAsync(s => s.Id == Id);
            if (data != null)
            {
                return new GetStoreProductDTO()
                {
                    Id = data.Id,
                    StoreId = data.StoreId,
                    ProductId = data.ProductId,
                    Quantity = data.Quantity,
                };
            }
            else
                throw new Exception("Not found!");
        }

        public async Task<List<GetStoreProductListDTO>> GeyAllStoreProduct()
        {
            var data = await context.StoreProducts.Include(s => s.Store).ToListAsync();
            if (data is null && !data.Any()) return [];
            var allStoreProduct = new List<GetStoreProductListDTO>();
            foreach ( var storeProduct in data)
            {
                allStoreProduct.Add(new GetStoreProductListDTO
                {
                    Id = storeProduct.Id,
                    StoreId = storeProduct.StoreId,
                    ProductId = storeProduct.ProductId,
                    Quantity = storeProduct.Quantity,
                });
            }
            return allStoreProduct;
        }

        public async Task UpdateStoreProduct(GetStoreProductDTO updateStoreProduct)
        {
            var old = await context.StoreProducts.FirstOrDefaultAsync(s => s.Id == updateStoreProduct.Id);
            if(old != null)
            {
                old.StoreId = updateStoreProduct.StoreId;
                old.ProductId = updateStoreProduct.ProductId;
                old.Quantity = updateStoreProduct.Quantity;

                context.StoreProducts.Update(old);
                await context.SaveChangesAsync();
            }
        }
    }
}
