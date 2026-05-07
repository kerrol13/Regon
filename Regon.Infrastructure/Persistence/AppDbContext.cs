using Microsoft.EntityFrameworkCore;
using Regon.Domain.Entities;

namespace Regon.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Costumers { get; set; }
    }
}
