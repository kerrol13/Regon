using Microsoft.EntityFrameworkCore;
using Regon.Domain.Repositories;
using Regon.Infrastructure.Persistence;

namespace Regon.Infrastructure.Repositories
{
    public abstract class BaseRepository<T>(AppDbContext context) : IBaseRepository<T> where T : class
    {
        public DbSet<T> Entities => context.Set<T>();

        public async Task AddAsync(T entity)
        {
            await Entities.AddAsync(entity);
        }
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await Entities.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }
        public async Task SaveChangesAsync()
        {
             await context.SaveChangesAsync();
        }
    }
}
