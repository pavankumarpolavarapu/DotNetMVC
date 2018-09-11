using Microsoft.EntityFrameworkCore;
using CoreCRUD.Models;

namespace CoreCRUD.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }
        public DbSet<CoreCRUD.Models.Collectible> Collectible { get; set; }
        public DbSet<CoreCRUD.Models.Manufacturer> Manufacturer { get; set; }
    }
}