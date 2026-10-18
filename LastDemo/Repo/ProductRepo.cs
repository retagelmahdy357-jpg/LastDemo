using LastDemo.Data;
using LastDemo.Model;
using LastDemo.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace LastDemo.Repo
{
    public class ProductRepo : GenericRepo<Product>, IProduct
    {
        private readonly AppDbContext _context;
        public ProductRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> Pagination(int categoryid, int pagenum, int pagesize, string SortBy)
        {
            var p = _context.Products.Where(x => x.CategoryId == categoryid).Skip((pagenum - 1) * pagesize).Take(pagesize);
            if (SortBy == "Price")
            {
                p = p.OrderBy(x => x.Price);
            }
            else if (SortBy == "StockQuantity")
            {
                p = p.OrderBy(x => x.StockQuantity);
            }
            else
            {
                p = p.OrderBy(x => x.Name);
            }

            return await p.ToListAsync();


        }


        public async Task<Product> SecoundMostExpensive(int catId)
        {
            return await _context.Products.Where(x => x.CategoryId != catId).OrderByDescending(x => x.Price).Skip(1).FirstOrDefaultAsync();
        }





        public async Task<List<Product>> Search(string Name)
        {
            return await _context.Products.Where(x => x.Name.Contains(Name)).ToListAsync();
        }
    }
}







       