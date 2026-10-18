using LastDemo.Model;

namespace LastDemo.Repo.IRepo
{
    public interface ICategory:IGenericRepo<Category>
    {
        public Task<List<Category>> GetProductsCategry();
    }
}
