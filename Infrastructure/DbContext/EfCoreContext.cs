using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext;

public class EfCoreContext : DbContext
{
    public EfCoreContext(DbContextOptions<EfCoreContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }

}
