using System.ComponentModel.DataAnnotations;

namespace JobFinderPractic.Models;

public class RegisterVM
{
    [Required]
    public string Fullname { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    [Required]
    public string Status { get; set; }
}