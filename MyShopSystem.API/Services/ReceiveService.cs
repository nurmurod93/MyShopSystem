using Commons.Models.Receive;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class ReceiveService(ApplicationDbContext context) : IReceivesService
    {
        public async Task<GetReceiveDTO> CreateReceive(CreateReceiveDTO createReceive)
        {
            var newEnttity = new Receive()
            {
                ProductName = createReceive.ProductName,
                Amount = createReceive.Amount,
                Price = createReceive.Price,
                Supplier = createReceive.Supplier,
                ReceivedDate = createReceive.ReceivedDate,
            };
            var entry = await context.Receives.AddAsync(newEnttity);
            await context.SaveChangesAsync();

            return new GetReceiveDTO()
            {
                ProductName = newEnttity.ProductName,
                Amount = newEnttity.Amount,
                Price = newEnttity.Price,
                Supplier = newEnttity.Supplier,
                ReceivedDate = newEnttity.ReceivedDate,
            };
        }

        public async Task DeleteReceiveById(int Id)
        {
            var data = await context.Receives.FirstOrDefaultAsync(r => r.Id == Id);
            if(data != null)
            {
                context.Receives.Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<GetReceiveListDTO>> GetAllReceive()
        {
            var data = await context.Receives
              .Select(r => new GetReceiveListDTO
              {
                  Id = r.Id,
                  ProductName = r.ProductName,
                  Amount = r.Amount,
                  Price = r.Price,
                  Supplier = r.Supplier,
                  ReceivedDate = r.ReceivedDate
              })
              .ToListAsync();

            return data;
        }

        public async Task<GetReceiveDTO> GetReceiveById(int Id)
        {
            var receive = await context.Receives.FindAsync(Id);
            if (receive == null)
                return null;

            return new GetReceiveDTO
            {
                Id = receive.Id,
                ProductName = receive.ProductName,
                Amount = receive.Amount,
                Price = receive.Price,
                Supplier = receive.Supplier,
                ReceivedDate = receive.ReceivedDate
            };
        }

        public async Task UpdateReceive(GetReceiveDTO updateReceive)
        {
            var old = await context.Receives.FirstOrDefaultAsync(r => r.Id == updateReceive.Id);
            if (old != null)
            {
                old.ProductName = updateReceive.ProductName;
                old.Amount = updateReceive.Amount;
                old.Price = updateReceive.Price;
                old.Supplier = updateReceive.Supplier;
                old.ReceivedDate = updateReceive.ReceivedDate;

                context.Receives.Update(old);
                await context.SaveChangesAsync();
            }
        }
    }
}
