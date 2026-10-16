using LastDemo.Data;
using LastDemo.Model;
using LastDemo.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace LastDemo.Repo
{
    public class OrderRepo:GenericRepo<Order>,IOrder
    {
        private readonly AppDbContext _context;
        public OrderRepo(AppDbContext context):base(context) {
        
             _context = context;
        }

        public async Task<Order> GetByIdList(int id)
        {
            return await _context.Orders.Include(x=>x.OrderIteams).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<decimal> TotalRevenue()
        {
            return  await _context.Orders.Where(x => x.Status == "Completed").SumAsync(x => x.TotalAmount);
        }
    }
}
