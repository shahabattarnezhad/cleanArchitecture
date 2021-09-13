using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Employee.Core.Entities.Employee> Employees { get; set; }
    }
}
