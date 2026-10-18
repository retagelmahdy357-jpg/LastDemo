using LastDemo.Model;

namespace LastDemo.Repo.IRepo
{
    public interface IProduct:IGenericRepo<Product>
    {
      public  Task<List<Product>> Pagination(int categoryid, int pagenum, int pagesize,string SortBy);

        public Task<Product> SecoundMostExpensive(int catId);
        public Task<List<Product>> Search(string Name);
    }
}
