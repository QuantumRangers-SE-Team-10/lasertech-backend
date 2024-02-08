using Microsoft.EntityFrameworkCore;

namespace lasertech_backend.Model;

public class SchoolContext: DbContext
{
    public DbSet<Student> Students { get; set; }

    public SchoolContext(DbContextOptions options) : base(options)
    {
        
    }
}