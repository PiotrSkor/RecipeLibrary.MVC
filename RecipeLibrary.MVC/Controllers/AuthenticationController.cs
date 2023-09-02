using Microsoft.AspNetCore.Mvc;
using RecipeLibrary.Application.Services;
using RecipeLibrary.Domain.Entities;

namespace RecipeLibrary.MVC.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (UserServices.CheckPassword(user)) 
            {
                UserServices.Register(user);
            };

            return RedirectToAction("Index", "Recipe");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
