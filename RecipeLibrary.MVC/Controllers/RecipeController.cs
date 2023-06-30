using Microsoft.AspNetCore.Mvc;

namespace RecipeLibrary.MVC.Controllers
{
    public class RecipeController : Controller
    {
        [HttpPost]
        public IActionResult Create(Domain.Entities.RecipeDetails recipeDetails)
        {
            RecipeLibrary.Application.Services.RecipeLibraryServices.Create(recipeDetails);
            return RedirectToAction(nameof(Create));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
