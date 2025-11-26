using CrudApplicatoin.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApplicatoin.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
            public DbSet<Employee> Employees { get; set; }
    }
}
