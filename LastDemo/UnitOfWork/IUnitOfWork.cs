using LastDemo.Model;
using LastDemo.Repo.IRepo;

namespace LastDemo.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IGenericRepo<User> Users {  get; }
        public ICategory Categories { get; }
        public IProduct Products { get; }
        public IOrder Orders { get; }
        public IGenericRepo<OrderIteam>OrderIteams { get; }
        public IAuth auth { get; }
        public Task Save();
    }
}
