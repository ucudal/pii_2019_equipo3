using Microsoft.EntityFrameworkCore;

namespace RazorPagesIgnis.Models
{
    public class RazorPagesIgnisContext : DbContext
    {
        public RazorPagesIgnisContext (DbContextOptions<RazorPagesIgnisContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesIgnis.Models.Technician> Technicians { get; set; }
    }
}