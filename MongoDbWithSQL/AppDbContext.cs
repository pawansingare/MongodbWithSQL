using Microsoft.EntityFrameworkCore;
using MongoDbWithSQL.Model;

namespace MongoDbWithSQL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<ChangedAudit> ChangedAudit { get; set; }
    }
}
