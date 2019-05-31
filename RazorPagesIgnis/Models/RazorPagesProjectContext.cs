using Microsoft.EntityFrameworkCore;

namespace RazorPagesIgnis.Models
{
    public class RazorPagesProjectContext : DbContext
    {
        public RazorPagesProjectContext (DbContextOptions<RazorPagesProjectContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesIgnis.Models.Project> Project { get; set; }
    }
}