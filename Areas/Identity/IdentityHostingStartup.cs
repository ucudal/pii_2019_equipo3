using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                services.AddDbContext<RazorPagesIgnisIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RazorPagesIgnisIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<RazorPagesIgnisIdentityDbContext>();
            });
        }
    }
}