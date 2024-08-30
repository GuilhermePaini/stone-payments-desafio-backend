using Microsoft.EntityFrameworkCore;
using Stone.StarstoreAPI.Models;

namespace Stone.StarstoreAPI.Data
{
    public class ProductContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }
    }
}
