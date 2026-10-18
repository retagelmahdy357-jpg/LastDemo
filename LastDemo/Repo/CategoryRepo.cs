using LastDemo.Data;
using LastDemo.Model;
using LastDemo.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace LastDemo.Repo
{
    public class CategoryRepo:GenericRepo<Category>,ICategory
    {
        private readonly AppDbContext _context;
        public CategoryRepo(AppDbContext context):base(context)
        {
             _context = context;
        }

        public async Task<List<Category>> GetProductsCategry()
        {
         return  await _context.Categories.Include(x=>x.Products).ToListAsync();
        }
    }
}
