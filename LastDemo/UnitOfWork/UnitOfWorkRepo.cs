using LastDemo.Data;
using LastDemo.Model;
using LastDemo.Repo.IRepo;

namespace LastDemo.UnitOfWork
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IGenericRepo<User> Users { get; }

        public ICategory Categories { get; }

        public IProduct Products { get; }

        public IOrder Orders { get; }

        public IGenericRepo<OrderIteam> OrderIteams { get; }

        public IAuth auth { get; }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
        public UnitOfWorkRepo(AppDbContext _context, IGenericRepo<User> _Users, ICategory _Categories, IProduct _Products, IOrder _Orders, IGenericRepo<OrderIteam> _OrderIteams, IAuth _auth)
        {
            context = _context;
            Users = _Users;
            Categories = _Categories;
            Products = _Products;
            Orders = _Orders;
            OrderIteams = _OrderIteams;
            auth = _auth;
             
        }
    }
}
