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
            Email = registerVm.Email
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
    public IActionResult LogOut()
    {
        return RedirectToAction("Index", "Home");
    }

    // Access Denied
    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
}
