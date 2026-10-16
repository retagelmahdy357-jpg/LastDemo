using LastDemo.Data;
using LastDemo.Model;
using LastDemo.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace LastDemo.Repo
{
    public class ProductRepo:GenericRepo<Product>,IProduct
    {
        private readonly AppDbContext _context;
        public ProductRepo(AppDbContext context):base(context)
        {
             _context = context;
        }

        public async Task<List<Product>> Pagination(int categoryid,int pagenum,int pagesize)
        {
          return  await _context.Products.Where(x=>x.CategoryId==categoryid).Skip((pagenum-1)*pagesize).Take(pagesize).OrderBy(x=>x.Price).ToListAsync();
        }

        public async Task<List<Product>> Search(string Name)
        {
            return await _context.Products.Where(x=>x.Name.Contains(Name)).ToListAsync();
        }

        public async Task<Product> SecoundMostExpensive(int catId)
        {
          return await _context.Products.Where(x=>x.CategoryId == catId).OrderByDescending(x=>x.Price).Skip(1).Take(1).FirstOrDefaultAsync();
            
        }
    }
}
