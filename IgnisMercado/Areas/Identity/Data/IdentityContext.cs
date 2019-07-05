using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesIgnis.Areas.Identity.Data
{
    public class IdentityContext : IdentityDbContext<ApplicationUser> 
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesIgnis.Models.Project> Project { get; set; }
        
        public DbSet<RazorPagesIgnis.Models.Technician> Technician { get; set; }

        public DbSet<RazorPagesIgnis.Models.Feedback> Feedback { get; set; }
        
        public DbSet<RazorPagesIgnis.Models.ProjectAssigned> ProjectAssigned { get; set; }
        
        public DbSet<RazorPagesIgnis.Models.ProjectFinished> ProjectFinished { get; set; }
        public DbSet<RazorPagesIgnis.Models.Client> Client { get; set; }
        
        
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);            
        }
    }
}