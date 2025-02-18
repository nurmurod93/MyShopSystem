using Commons.Models.WarehouseDTO;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class WarehouseService(ApplicationDbContext context) : IWarehouceService
    {
        public async Task<GetWarehouseDTO> CreateWarehouse(CreateWarehouseDTO createWarehouse)
        {
            var newEntity = new Warehouse()
            {
                Id = createWarehouse.Id,
                Name = createWarehouse.Name,
                Location = createWarehouse.Location,
            };
            var entry = await context.Warehouses.AddAsync(newEntity);
            await context.SaveChangesAsync();

            return new GetWarehouseDTO
            {
                Id = newEntity.Id,
                Name = newEntity.Name,
                Location = newEntity.Location,
            };
        }

        public async Task DeleteWarehouse(int Id)
        {
            var data = await context.Warehouses.FirstOrDefaultAsync(w => w.Id == Id);
            if (data != null)
            {
                context.Warehouses.Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<GetWarehouseListDTO>> GetAllWarehouse()
        {
            var data = await context.Warehouses.Include(w => w.WarehouseProducts).ToListAsync();
            if (data is null && !data.Any()) return [];
            var allWarehouse = new List<GetWarehouseListDTO>();
            foreach (var warehouse in data)
            {
                allWarehouse.Add(new GetWarehouseListDTO
                {
                    Id = warehouse.Id,
                    Name = warehouse.Name,
                    Location = warehouse.Location,
                });
            }
            return allWarehouse;
        }

        public async Task<GetWarehouseDTO> GetWarehouse(int Id)
        {
            var data = await context.Warehouses.Include(w => w.WarehouseProducts).FirstOrDefaultAsync(w => w.Id == Id);
            if (data != null)
            {
                return new GetWarehouseDTO()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Location = data.Location,
                };
            }
            else
                throw new Exception("Not found!");
        }

        public async Task UpdateWarehouse(GetWarehouseDTO updateWarehouse)
        {
            var old = await context.Warehouses.FirstOrDefaultAsync(w => w.Id == updateWarehouse.Id);
            if (old != null)
            {
                old.Name = updateWarehouse.Name;
                old.Location = updateWarehouse.Location;

                context.Warehouses.Update(old);
                await context.SaveChangesAsync();
            }
        }
    }
}
