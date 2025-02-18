using Commons.Models.OrderDetailDTO;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class OrderDetailsService(ApplicationDbContext context) : IOrderDetailsService
    {
        public async Task<GetOrderDetailDTO> CreateOrderDetail(CreateOrderDetailDTO createOrderDetail)
        {
            var newEntry = new OrderDetail()
            {
                Id = createOrderDetail.Id,
                ProductId = createOrderDetail.ProductId,
                OrderId = createOrderDetail.OrderId,
                TotalPrice = createOrderDetail.TotalPrice,
                Quantity = createOrderDetail.Quantity,
            };

            var entry = await context.OrderDetails.AddAsync(newEntry);
            await context.SaveChangesAsync();

            return new GetOrderDetailDTO()
            {
                Id = newEntry.Id,
                ProductId = newEntry.ProductId,
                OrderId = newEntry.OrderId,
                TotalPrice = newEntry.TotalPrice,
                Quantity = newEntry.Quantity,
            };
        }

        public async Task DeleteOrderDetail(int Id)
        {
            var data = await context.OrderDetails.FirstOrDefaultAsync(o => o.Id == Id);
            if(data != null)
            {
                context.OrderDetails.Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<GetOrderDetailListDTO>> GetAllOrderDetails()
        {
            var data = await context.OrderDetails.Include(o => o.Order).ToListAsync();
            if (data is null && !data.Any()) return [];
            var allOrderDetails = new List<GetOrderDetailListDTO>();

            foreach (var orderDetails in data)
            {
                allOrderDetails.Add(new GetOrderDetailListDTO
                {
                    Id = orderDetails.Id,
                    ProductId = orderDetails.ProductId,
                    OrderId = orderDetails.OrderId,
                    TotalPrice = orderDetails.TotalPrice,
                    Quantity = orderDetails.Quantity,

                });
            }
            return allOrderDetails;
        }

        public async Task<GetOrderDetailDTO> GetOrderDetail(int Id)
        {
            var data = await context.OrderDetails.Include(o => o.Order).FirstOrDefaultAsync(o => o.Id == Id);
            if (data != null)
            {
                return new GetOrderDetailDTO
                {
                    Id = data.Id,
                    ProductId = data.ProductId,
                    OrderId = data.OrderId,
                    TotalPrice = data.TotalPrice,
                    Quantity = data.Quantity,

                };
            }
            else
                throw new Exception("Not fount!");
        }

        public async Task UpdateOrderDetail(GetOrderDetailDTO updateorderDetail)
        {
            var old = await context.OrderDetails.FirstOrDefaultAsync(o => o.Id == updateorderDetail.Id);
            if (old != null)
            {
                old.ProductId = updateorderDetail.ProductId;
                old.OrderId = updateorderDetail.OrderId;
                old.TotalPrice = updateorderDetail.TotalPrice;
                old.Quantity = updateorderDetail.Quantity;

                context.OrderDetails.Update(old);
                await context.SaveChangesAsync();
            }
        }
    }
}
