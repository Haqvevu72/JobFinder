using Microsoft.AspNetCore.Identity;

namespace JobFinderPractic.Domain.Entities.Concretes;

public class AppUser: IdentityUser
{
    public string Fullname { get; set; }
    public string Status { get; set; }
    public string PasswordConfirm { get; set; }
}