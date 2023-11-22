using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace CRUDWithBlazor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}