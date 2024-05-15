using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinderPractic.Controllers;

public class AccountController : Controller
{
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
