using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesIgnis.Areas.Identity.Data;

[assembly: HostingStartup(typeof(RazorPagesIgnis.Areas.Identity.IdentityHostingStartup))]
namespace RazorPagesIgnis.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDefaultIdentity<ApplicationUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<IdentityContext>();
            });
        }
    }
}