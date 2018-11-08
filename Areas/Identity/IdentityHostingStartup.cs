using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecondAspNetTutorial.Areas.Identity.Data;

[assembly: HostingStartup(typeof(SecondAspNetTutorial.Areas.Identity.IdentityHostingStartup))]
namespace SecondAspNetTutorial.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SecondAspNetTutorialIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SecondAspNetTutorialIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<SecondAspNetTutorialIdentityDbContext>();
            });
        }
    }
}