using Commons.Models.StoreDTO;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class StoreService(ApplicationDbContext context) : IStoreService
    {
        public async Task<GetStoreDTO> CreateStore(CreateStoreDTO createStore)
        {
            var newEntity = new Store()
            {
                Id = createStore.Id,
                Name = createStore.Name,
                Location = createStore.Location,
                BranchId = createStore.BranchId,
            };
            var entry = await context.Stores.AddAsync(newEntity);
            await context.SaveChangesAsync();

            return new GetStoreDTO
            {
                Id = newEntity.Id,
                Name = newEntity.Name,
                Location = newEntity.Location,
                BranchId = newEntity.BranchId,
            };
        }

        public async Task DeleteStore(int Id)
        {
            var data = await context.Stores.FirstOrDefaultAsync(s => s.Id == Id);
            if (data != null)
            {
                context.Stores.Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<GetStoreListDTO>> GetAllStore()
        {
            var data = await context.Stores.Include(s => s.StoreProducts).ToListAsync();
            if (data is null && !data.Any()) return [];
            var allStore = new List<GetStoreListDTO>();
            foreach ( var store in data)
            {
                allStore.Add(new GetStoreListDTO
                {
                    Id = store.Id,
                    Name = store.Name,
                    Location = store.Location,
                    BranchId = store.BranchId,
                });
            }
            return allStore;
        }

        public async Task<GetStoreDTO> GetStore(int Id)
        {
            var data = await context.Stores.Include(s => s.StoreProducts).FirstOrDefaultAsync();
            if (data != null)
            {
                return new GetStoreDTO()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Location = data.Location,
                    BranchId = data.BranchId,
                };
            }
            else
                throw new Exception("Not found!");
        }

        public async Task UpdateStore(GetStoreDTO updaeStore)
        {
            var old = await context.Stores.FirstOrDefaultAsync(s => s.Id == updaeStore.Id);
            if(old != null)
            {
                old.Name = updaeStore.Name;
                old.Location = updaeStore.Location;
                old.BranchId = updaeStore.BranchId;

                context.Stores.Update(old);
                await context.SaveChangesAsync();
            }
        }
    }
}
