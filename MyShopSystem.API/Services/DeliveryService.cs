using Commons.Models.DeliveryDTO;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class DeliveryService(ApplicationDbContext context) : IDeliveryService
    {
        public async Task<GetDeliveryDTO> CreateDelivery(CreateDeliveryDTO delivery)
        {
            var newEntry = new Delivery()
            {
                WarehouseId = delivery.WarehouseId,
                StoreId = delivery.StoreId,
                DeliveryDate = delivery.DeliveryDate,

            };

            var entry = await context.Deliveries.AddAsync(newEntry);
            await context.SaveChangesAsync();

            return new GetDeliveryDTO()
            {
                Id = newEntry.Id,
                WarehouseId = newEntry.WarehouseId,
                StoreId = newEntry.StoreId,
                DeliveryDate = delivery.DeliveryDate,
            };
        }

        public async Task DeleteDelivery(int Id)
        {
            var data = await context.Deliveries.FirstOrDefaultAsync(d => d.Id == Id);
            if(data != null)
            {
                context.Deliveries.Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<GetDeliveryListDTO>> GetAllDelivery()
        {
            var data = await context.Deliveries.Include(d => d.DeliveryDetails).ToListAsync();
            if (data is null && !data.Any()) return [];
                var allDelivery = new List<GetDeliveryListDTO>();

            foreach (var deliveries in data)
            {
                allDelivery.Add(new GetDeliveryListDTO
                {
                    Id = deliveries.Id,
                    WarehouseId= deliveries.WarehouseId,
                    StoreId = deliveries.StoreId,
                    DeliveryDate = deliveries.DeliveryDate,
                });
            }
            return allDelivery;
        }

        public async Task<GetDeliveryDTO> GetDelivery(int Id)
        {
            var data = await context.Deliveries.Include(d => d.DeliveryDetails).FirstOrDefaultAsync(x => x.Id == Id);
            if (data != null)
            {
                return new GetDeliveryDTO()
                {
                    Id = data.Id,
                    WarehouseId = data.WarehouseId,
                    StoreId = data.StoreId,
                    DeliveryDate = data.DeliveryDate,
                };
            }
            else
                throw new Exception("Not found!");
        }

        public async Task UpdateDelivery(GetDeliveryDTO updateDelivery)
        {
            var old = await context.Deliveries.FirstOrDefaultAsync(d => d.Id == updateDelivery.Id);
            if(old != null)
            {
                old.WarehouseId = updateDelivery.WarehouseId;
                old.StoreId = updateDelivery.StoreId;
                old.DeliveryDate = updateDelivery.DeliveryDate;

                context.Deliveries.Update(old);
                await context.SaveChangesAsync();
            }
        }
    }
}
