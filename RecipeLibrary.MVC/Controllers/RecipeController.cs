using Microsoft.AspNetCore.Mvc;
using RecipeLibrary.Application.Services;
using RecipeLibrary.Domain.Entities;

namespace RecipeLibrary.MVC.Controllers
{
    public class RecipeController : Controller
    {
        [HttpPost]
        public IActionResult Create(RecipeDetails recipeDetails)
        {
            if (ModelState.IsValid)
            {
                return View(recipeDetails);
            }
            RecipeLibraryServices.Create(recipeDetails);
            return RedirectToAction(nameof(Create));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await RecipeLibraryServices.ReadDataFromFirebase();
            return View(recipes);
        }

        public async Task<IActionResult> Details()
        {
            var x = await RecipeLibraryServices.ReadDataFromFirebase();

            var recipe = RecipeLibraryServices.GetByEncodedName(x);
            

            return View(recipe);
        }
    }
}
