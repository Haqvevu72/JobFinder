using Microsoft.AspNetCore.Identity;

namespace JobFinderPractic.Domain.Entities.Concretes;

public class AppUser: IdentityUser
{
    public string Fullname { get; set; }
}