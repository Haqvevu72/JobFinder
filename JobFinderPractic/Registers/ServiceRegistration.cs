using JobFinderPractic.DataAccess.Data;
using JobFinderPractic.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobFinderPractic.Registers;

public static class ServiceRegistration
{
    public static void AddDbContextServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<JobFinderDb>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("default")));
    }

    public static void AddRepositoryServices(this IServiceCollection collection)
    {

    }

    public static void AddIdentityConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<JobFinderDb>()
              .AddDefaultTokenProviders();
    }
}
