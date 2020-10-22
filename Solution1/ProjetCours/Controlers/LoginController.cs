using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Schema;
using ProjetCours.Data;
using ProjetCours.Models;

namespace ProjetCours.Controlers
{
    public class LoginController : Controller
    {
       // private readonly ProjetCoursContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<HomeController> _logger;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind("userName, email, password")] RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser();
                user.UserName = register.userName;
                user.Email = register.email;
                var result = await _userManager.CreateAsync(user, register.password);
                if (result.Succeeded)
                {
                    return LocalRedirect("~/Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                }
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index([Bind("userName, email, password")] RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(register.userName, register.password, false, true);
                if (result.Succeeded)
                {
                    return LocalRedirect("~/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "le login ou le mot de passe ne sont pas correct");
                }

            }
            return View();

        }

    }
}
