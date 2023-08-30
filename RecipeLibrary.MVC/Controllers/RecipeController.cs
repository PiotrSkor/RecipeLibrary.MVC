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

        [HttpPost]
        public IActionResult Edit(RecipeDetailsDto recipeDetails)
        {
            if (ModelState.IsValid)
            {
                return View(recipeDetails);
            }
            RecipeLibraryServices.Create(recipeDetails);
            return RedirectToAction(nameof(Create));
        }

        [HttpGet]
        public IActionResult Edit(RecipeDetails recipe)
        {
            return View(recipe);
        }

    
        [HttpGet]
        public async Task<IActionResult> Delete(string encodedName, string descriptionShort)
        {
            var x = await RecipeLibraryServices.ReadDataFromFirebase();

            
            RecipeLibraryServices.DeleteRecipe(encodedName, descriptionShort);
            return RedirectToAction("Index");
        }
      

        public async Task<IActionResult> Index()
        {
            var recipes = await RecipeLibraryServices.ReadDataFromFirebase();
            return View(recipes);
        }


        [HttpGet]
        public async Task<IActionResult> Details(string encodedName, string descriptionShort)
        {
            var x = await RecipeLibraryServices.ReadDataFromFirebase();

            var details = RecipeLibraryServices.GetByEncodedName(x, encodedName, descriptionShort);


            return View(details);
        }
       

      
    }
}
