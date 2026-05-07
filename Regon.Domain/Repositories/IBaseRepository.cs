using Microsoft.EntityFrameworkCore;

namespace Regon.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        DbSet<T> Entities { get; }
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}