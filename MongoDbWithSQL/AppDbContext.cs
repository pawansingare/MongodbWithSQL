using Microsoft.EntityFrameworkCore;
using MongoDbWithSQL.Model;

namespace MongoDbWithSQL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<EmployeeContactDetails> EmployeeContactDetails { get; set; }
    }
}
