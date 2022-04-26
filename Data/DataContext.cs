using Microsoft.EntityFrameworkCore;
using Entity;

namespace Data
{
    public class DataContext : DbContext {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Animal> Animals { get; set; }
    }
}