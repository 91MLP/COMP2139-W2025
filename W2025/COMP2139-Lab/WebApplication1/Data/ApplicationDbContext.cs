using Microsoft.EntityFrameworkCore;

namespace DefaultNamespace;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Project>Projects { get; set; }
    
}