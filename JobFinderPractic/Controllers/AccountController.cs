using JobFinderPractic.Domain.Entities.Concretes;
using JobFinderPractic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobFinderPractic.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager; 
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> _userManager , SignInManager<AppUser> _signInManager)
    {
        this._userManager = _userManager;
        this._signInManager = _signInManager;
    }
    // Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVm)
    {
        if (!ModelState.IsValid)
            return View(loginVm);

        var user = await _userManager.FindByEmailAsync(loginVm.Email);
        
        if (user is null)
        {
            ModelState.AddModelError("All", "User not found");
            return View(loginVm);
        }
        
        var result = await _userManager.CheckPasswordAsync(user, loginVm.Password);

        if (result == false)
        {
            ModelState.AddModelError("All", "Password is wrong");
            return View(loginVm);
        }
        
        await _signInManager.SignInAsync(user, loginVm.RememberMe);

        return RedirectToAction("Index", "Home");
    }

    // Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerVm)
    {
        if (!ModelState.IsValid)
            return View(registerVm);

        AppUser appUser = new AppUser()
        {
            UserName = registerVm.Email,
            Email = registerVm.Email,
            Status = registerVm.Status,
            Fullname = registerVm.Fullname,
            PasswordConfirm = registerVm.ConfirmPassword
        };

        var result = await _userManager.CreateAsync(appUser, registerVm.Password);

        if (result.Succeeded)
            return RedirectToAction("Login");
        else
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("All" , item.Description);
            }
        }

        return View(registerVm);
    }

    // LogOut
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // Access Denied
    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
}
