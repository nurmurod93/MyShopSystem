using Commons.Models.Send;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class SendService(ApplicationDbContext context) : ISendService
    {
        public async Task<GetSendDTO> CreateSend(CreateSendDTO createSend)
        {
            var newEntity = new Send()
            {
                Id = createSend.Id,
                Amount = createSend.Amount,
                PhoneNumber = createSend.PhoneNumber,
                Type = createSend.Type,
            };

            var entry = await context.Sends.AddAsync(newEntity);
            await context.SaveChangesAsync();

            return new GetSendDTO
            {
                Id = newEntity.Id,
                Amount = newEntity.Amount,
                PhoneNumber = newEntity.PhoneNumber,
                Type = newEntity.Type,
            };
        }

        public async Task DeleteSend(int Id)
        {
            var data = await context.Sends.FirstOrDefaultAsync(s => s.Id == Id);
            if (data != null)
            {
                context.Sends.Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<GetSendListDTO>> GetAllSend()
        {
            var data = await context.Sends.ToListAsync();
            return data.Select(s => new GetSendListDTO
            {
                Id = s.Id,
                Amount = s.Amount,
                PhoneNumber = s.PhoneNumber,
                Type = s.Type,
            }).ToList();
        }

        public async Task<GetSendDTO> GetSend(int Id)
        {
            var data = await context.Sends.FindAsync(Id);
            if (data == null)
                throw new KeyNotFoundException("Send not found!");

            return new GetSendDTO
            {
                Id = data.Id,
                Amount = data.Amount,
                PhoneNumber = data.PhoneNumber,
                Type = data.Type,
            };
        }

        public async Task UpdateSend(GetSendDTO updateSend)
        {
            var old = await context.Sends.FindAsync(updateSend.Id);
            if (old == null)
                throw new KeyNotFoundException("Send not found!");

            old.Amount = updateSend.Amount;
            old.PhoneNumber = updateSend.PhoneNumber;
            old.Type = updateSend.Type;

            await context.SaveChangesAsync();
        }
    }
}
