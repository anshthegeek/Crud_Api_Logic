using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Crud_angular_dotnet.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            }
        public DbSet<Employee> Employees { get; set; }
 
    }
}
