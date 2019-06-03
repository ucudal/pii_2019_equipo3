using Microsoft.EntityFrameworkCore;

namespace RazorPagesIgnis.Models
{
    public class RazorPagesIgnisContext : DbContext
    {
        public RazorPagesIgnisContext (DbContextOptions<RazorPagesIgnisContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesIgnis.Models.Project> Project { get; set; }
        public DbSet<RazorPagesIgnis.Models.Technician> Technician { get; set; }
        public DbSet<RazorPagesIgnis.Models.ProjectAssigned> ProjectAssigned { get; set; }
        public DbSet<RazorPagesIgnis.Models.ProjectFinished> ProjectFinished { get; set; }
        public DbSet<RazorPagesIgnis.Models.Client> Client { get; set; }
    }
}