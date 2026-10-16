using LastDemo.Model;

namespace LastDemo.Repo.IRepo
{
    public interface IOrder:IGenericRepo<Order>
    {
        public Task<Order>GetByIdList(int id);
        public Task<decimal> TotalRevenue();
    }
}
