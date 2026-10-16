using LastDemo.Data;
using LastDemo.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace LastDemo.Repo
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        public GenericRepo(AppDbContext context)
        {
            _context = context; 
        }
        public async Task add(TEntity tentity)
        {
         await  _context.Set<TEntity>().AddAsync(tentity);
        }

        public void Delete(TEntity tentity)
        {
            _context.Set<TEntity>().Remove(tentity);
        }

        public async Task<List<TEntity>> GetAll()
        {
           return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
            
        }

        public void Update(TEntity tentity)
        {
            _context.Set<TEntity>().Update(tentity);
        }
    }
}
