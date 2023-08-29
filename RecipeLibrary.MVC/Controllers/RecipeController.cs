using Microsoft.AspNetCore.Mvc;
using RecipeLibrary.Application.Mappings;
using RecipeLibrary.Application.Services;
using RecipeLibrary.Domain.Entities;

namespace RecipeLibrary.MVC.Controllers
{
    public class RecipeController : Controller
    {
        [HttpPost]
        public IActionResult Create(RecipeDetailsDto recipeDetails)
        {
            if (ModelState.IsValid)
            {
                return View(recipeDetails);
            }
            RecipeLibraryServices.Create(recipeDetails);
            return RedirectToAction(nameof(Create));
        }
        [HttpGet]
        public IActionResult Create(RecipeDetails recipe)
        {
            return View(recipe);
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await RecipeLibraryServices.ReadDataFromFirebase();
            return View(recipes);
        }

        public async Task<IActionResult> Details(string encodedName)
        {
            var x = await RecipeLibraryServices.ReadDataFromFirebase();

            var details = RecipeLibraryServices.GetByEncodedName(x, encodedName);

            

            return View(details);
        }

      
    }
}
