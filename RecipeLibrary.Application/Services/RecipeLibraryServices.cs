using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RecipeLibrary.Domain.Entities;


namespace RecipeLibrary.Application.Services
{
    public class RecipeLibraryServices
    {

        public static void Create(RecipeDetails recipeDetails)
        {
            if (recipeDetails.Name != null)
            {
                string authSecret = "AgmJVhSXQ3hNPwu6Fti6QstWbKZeB4cLLxGIrQqK"; //StringHelper.GetAppSettings(Constants.AppSetingTypes.Firebase, "AuthSecret");
                string basePath = "https://recipelibrary-d8e55-default-rtdb.europe-west1.firebasedatabase.app/";//StringHelper.GetAppSetings(Constants.AppSetingTypes.Firebase, "BasePath");
                string senderAppName = "RecipeLibrary";//StringHelper.GetAppSetings(Constants.AppSetingTypes.Firebase, "SenderApplicationName");

                IFirebaseConfig config = new FirebaseConfig
                {
                    AuthSecret = authSecret,
                    BasePath = basePath
                };
                IFirebaseClient client = new FireSharp.FirebaseClient(config);

                if (client != null && !string.IsNullOrEmpty(authSecret) && !string.IsNullOrEmpty(basePath))
                {
                    recipeDetails.EncodingName();
                    client.Push("Recipes/", recipeDetails);
                }
            }
        }


        public static async Task<List<RecipeDetails>> ReadDataFromFirebase()
        {
            string authSecret = "AgmJVhSXQ3hNPwu6Fti6QstWbKZeB4cLLxGIrQqK"; //StringHelper.GetAppSettings(Constants.AppSetingTypes.Firebase, "AuthSecret");
            string basePath = "https://recipelibrary-d8e55-default-rtdb.europe-west1.firebasedatabase.app/";//StringHelper.GetAppSetings(Constants.AppSetingTypes.Firebase, "BasePath");
            string senderAppName = "RecipeLibrary";//StringHelper.GetAppSetings(Constants.AppSetingTypes.Firebase, "SenderApplicationName");

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

        public static RecipeDetails GetByEncodedName(List<RecipeDetails> encodedName)
        {
            string authSecret = "AgmJVhSXQ3hNPwu6Fti6QstWbKZeB4cLLxGIrQqK"; //StringHelper.GetAppSettings(Constants.AppSetingTypes.Firebase, "AuthSecret");
            string basePath = "https://recipelibrary-d8e55-default-rtdb.europe-west1.firebasedatabase.app/";//StringHelper.GetAppSetings(Constants.AppSetingTypes.Firebase, "BasePath");
            string senderAppName = "RecipeLibrary";//StringHelper.GetAppSetings(Constants.AppSetingTypes.Firebase, "SenderApplicationName");

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath
            };
            IFirebaseClient client = new FirebaseClient(config);


            client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Recipes/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var recipes = new RecipeDetails();

            foreach (var item in data)
            {
                if (encodedName == item.EncodedName)
                {
                    recipes.Name= item.Name;
                    recipes.DescriptionShort= item.Description;
                    recipes.DescriptionLong= item.Description;
                    recipes.IngredientName= item.IngredientName;
                    recipes.IngredientValue= item.IngredientValue;
                    recipes.CreatedAt= item.CreatedAt;
                }
            }

            return recipes;
        }
    }
}
