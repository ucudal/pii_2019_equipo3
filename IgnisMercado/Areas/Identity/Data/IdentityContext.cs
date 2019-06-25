using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        
        public DbSet<RazorPagesIgnis.Models.ProjectAssigned> ProjectAssigned { get; set; }
        
        public DbSet<RazorPagesIgnis.Models.Client> Client { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            
        }
    }
}