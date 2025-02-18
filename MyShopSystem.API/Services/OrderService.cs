
using Commons.Models.OrderDTO;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class OrderService(ApplicationDbContext context) : IOrderService
    {
        public async Task<GetOrderDTO> CreateOrder(CreateOrderDTO order)
        {
            var newEntity = new Order()
            {
                StoreId = order.StoreId,
                OrderDate = order.OrderDate,
            };

            var entry = await context.Orders.AddAsync(newEntity);
            await context.SaveChangesAsync();

            return new GetOrderDTO()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                StoreId = order.StoreId,
            };
        }

        public async Task DeleteOrder(int Id)
        {
            var data = await context.Orders.FirstOrDefaultAsync(o => o.Id == Id);
            if(data != null)
            {
                context.Orders.Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<GetOrderListDTO>> GetAllOrder()
        {
            var data = await context.Orders.Include(o => o.OrderDetails).ToListAsync();
            if (data is null && !data.Any()) return [];
            var allOrder = new List<GetOrderListDTO>();
            foreach (var order in data)
            {
                allOrder.Add(new GetOrderListDTO
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    StoreId = order.StoreId,
                });
            }
            return allOrder;
        }

        public async Task<GetOrderDTO> GetOrder(int Id)
        {
            var data = await context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == Id);
            if (data != null)
            {
                return new GetOrderDTO()
                {
                    Id = data.Id,
                    OrderDate = data.OrderDate,
                    StoreId = data.StoreId,
                };
            }
            else
                throw new Exception("Not found!");
        }

        public async Task UpdateOrder(GetOrderDTO updateorder)
        {
            var old = await context.Orders.FirstOrDefaultAsync(o => o.Id == updateorder.Id);
            if(old != null)
            {
                old.OrderDate = updateorder.OrderDate;
                old.StoreId = updateorder.StoreId;
                
                context.Orders.Update(old);
                await context.SaveChangesAsync();
            }
        }
    }
}
