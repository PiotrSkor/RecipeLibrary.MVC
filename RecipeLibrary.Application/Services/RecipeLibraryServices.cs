using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RecipeLibrary.Application.Mappings;
using RecipeLibrary.Domain.Entities;


namespace RecipeLibrary.Application.Services
{
    public class RecipeLibraryServices
    {

        public static void Create(RecipeDetailsDto recipeDetails)
        {
            if (recipeDetails.Name != null)
            {
                string authSecret = "AgmJVhSXQ3hNPwu6Fti6QstWbKZeB4cLLxGIrQqK"; //StringHelper.GetAppSettings(Constants.AppSetingTypes.Firebase, "AuthSecret");
                string basePath = "https://recipelibrary-d8e55-default-rtdb.europe-west1.firebasedatabase.app/";//StringHelper.GetAppSetings(Constants.AppSetingTypes.Firebase, "BasePath");

                IFirebaseConfig config = new FirebaseConfig
                {
                    AuthSecret = authSecret,
                    BasePath = basePath
                };
                IFirebaseClient client = new FirebaseClient(config);

                if (client != null && !string.IsNullOrEmpty(authSecret) && !string.IsNullOrEmpty(basePath))
                {
                    recipeDetails.EncodingName();
                   // recipeDetails.Ingredients.Add(new Ingredient { NameIng = ingredient.NameIng , Type = ingredient.Type , Value =  ingredient.Value});

                    client.Push("Recipes/", recipeDetails);
                }
            }
        }


        public static async Task<List<RecipeDetails>> ReadDataFromFirebase()
        {
            string authSecret = "AgmJVhSXQ3hNPwu6Fti6QstWbKZeB4cLLxGIrQqK"; //StringHelper.GetAppSettings(Constants.AppSetingTypes.Firebase, "AuthSecret");
            string basePath = "https://recipelibrary-d8e55-default-rtdb.europe-west1.firebasedatabase.app/";//StringHelper.GetAppSetings(Constants.AppSetingTypes.Firebase, "BasePath");

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath
            };
            IFirebaseClient client = new FireSharp.FirebaseClient(config);


            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Recipes/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var recipes = new List<RecipeDetails>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    recipes.Add(JsonConvert.DeserializeObject<RecipeDetails>(((JProperty)item).Value.ToString()));
                }
            }

            return recipes;
        }

        public static RecipeDetails GetByEncodedName(List<RecipeDetails> encodedName, string encodedNameFromDisplay)
        {
            foreach (var item in encodedName)
            {
                if (item.EncodedName == encodedNameFromDisplay)
                {
                    
                    return item;
                }
            }

            return null;
        }
    }
}
