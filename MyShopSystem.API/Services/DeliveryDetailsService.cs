using Commons.Models.DeliveryDetailDTO;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class DeliveryDetailsService(ApplicationDbContext context) : IDeliveryDetailsService
    {
        public async Task<GetDeliveryDetailDTO> CreateDeliveryDetails(CreateDeliveryDetailDTO deliveryDetail)
        {
            var newEntity = new DeliveryDetail()
            {
                Id = deliveryDetail.Id,
                Quantity = deliveryDetail.Quantity,
                ProductId = deliveryDetail.ProductId,
                DeliveryId = deliveryDetail.DeliveryId,
            };

            var entry = await context.DeliveryDetails.AddAsync(newEntity);
            await context.SaveChangesAsync();

            return new GetDeliveryDetailDTO()
            {
                Id = newEntity.Id,
                Quantity = newEntity.Quantity,
                ProductId = newEntity.ProductId,
                DeliveryId = newEntity.DeliveryId,

            };
        }

        public async Task DeleteDeliveryDetails(int Id)
        {
            var data = await context.DeliveryDetails.FirstOrDefaultAsync(e => e.Id == Id);
            if(data != null)
            {
                context.DeliveryDetails.Remove(data);
                await context.SaveChangesAsync();
            };
        }

        public async Task<List<GetDeliveryDetailListDTO>> GetAllDeliveryDetails()
        {
            var data = await context.DeliveryDetails.Include(e => e.Delivery).ToListAsync();
            if (data is null && !data.Any()) return [];
            var allDeliveryDetails = new List<GetDeliveryDetailListDTO>();

            foreach(var delevery in data)
            {
                allDeliveryDetails.Add(new GetDeliveryDetailListDTO
                {
                    Id = delevery.Id,
                    Quantity = delevery.Quantity,
                    ProductId = delevery.ProductId,
                    DeliveryId = delevery.DeliveryId,

                });
            }
            return allDeliveryDetails;
        }

        public async Task<GetDeliveryDetailDTO> GetDeliveryDetatails(int Id)
        {
            var data = await context.DeliveryDetails.Include(e => e.Delivery).FirstOrDefaultAsync(e => e.Id == Id);
            if (data != null)
            {
                return new GetDeliveryDetailDTO()
                {
                    Id = data.Id,
                    Quantity = data.Quantity,
                    ProductId = data.ProductId,
                    DeliveryId = data.DeliveryId,
                };
            }
            else
                throw new Exception("Not found!");
        }

        public async Task UpdateDeliveryDetails(GetDeliveryDetailDTO updateDeDt)
        {
            var old = await context.DeliveryDetails.FirstOrDefaultAsync(e => e.Id == updateDeDt.Id);
            if(old != null)
            {
                old.Quantity = updateDeDt.Quantity;
                old.ProductId = updateDeDt.ProductId;
                old.DeliveryId = updateDeDt.DeliveryId;
            }
        }
    }
}
