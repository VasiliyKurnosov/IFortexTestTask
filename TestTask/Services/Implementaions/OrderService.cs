using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public OrderService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Order> GetOrder()
        {
            return await applicationDbContext.Orders.OrderByDescending(order => order.Price).FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await applicationDbContext.Orders.Where(order => order.Quantity > 10).ToListAsync();
        }
    }
}
