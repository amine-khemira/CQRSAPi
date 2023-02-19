using cqrssAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace cqrssAPI.Context
{
    public interface IApplicationContext
    {
        DbSet<User> Users { get; set; }

        Task<int> SaveChanges();
    }
}