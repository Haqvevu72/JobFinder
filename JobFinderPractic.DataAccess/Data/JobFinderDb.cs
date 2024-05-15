using JobFinderPractic.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobFinderPractic.DataAccess.Data;

public class JobFinderDb: IdentityDbContext<AppUser>
{
    public JobFinderDb(DbContextOptions<JobFinderDb> options) : base(options)
    {
        
    }
}