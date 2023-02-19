using cqrssAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace cqrssAPI.Context;
public class ApplicationContext : DbContext, IApplicationContext
{
    public DbSet<User> Users { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    { }

    public async Task<int> SaveChanges() => await base.SaveChangesAsync();
}
