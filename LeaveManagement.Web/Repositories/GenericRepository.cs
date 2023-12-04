using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity is not null)
            {
                _context.Set<T>().Remove(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity is not null;
        }

        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            //context.Entry(entity).State = EntityState.Modified; Another option
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
