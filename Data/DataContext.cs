using Microsoft.EntityFrameworkCore;
using Entity;

namespace Data
{
    public class DataContext : DbContext {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Adopter> Adopter { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}