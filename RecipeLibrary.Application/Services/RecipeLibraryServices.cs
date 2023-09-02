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
                var client = ConectToFirebase.ConectToFirebaseMethod();
               
                recipeDetails.EncodingName();

                client.Push("Recipes/", recipeDetails);
                
            }
        }


        public static async Task<List<RecipeDetails>> ReadDataFromFirebase()
        {
            var client = ConectToFirebase.ConectToFirebaseMethod();

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

        public static RecipeDetails GetByEncodedName(List<RecipeDetails> encodedName, string encodedNameFromDisplay, string descriptionShort)
        {
            foreach (var item in encodedName)
            {
                if (item.EncodedName == encodedNameFromDisplay && item.DescriptionShort == descriptionShort)
                {

                    return item;
                }
            }

            return null;
        }

        public static void DeleteRecipe(string encodedName, string descriptionShort)
        {
            try
            {
                var client = ConectToFirebase.ConectToFirebaseMethod();

                var recipesReference = client.Get("Recipes/").ResultAs<Dictionary<string, RecipeDetailsDto>>();

                // Znajdź klucz rekordu na podstawie encodedName
                string keyToDelete = recipesReference.FirstOrDefault(pair => pair.Value.EncodedName == encodedName && pair.Value.DescriptionShort == descriptionShort).Key;

                if (!string.IsNullOrEmpty(keyToDelete))
                {
                    string path = "Recipes/" + keyToDelete;

                    // Usuń rekord
                    FirebaseResponse response = client.Delete(path);
                }
                else
                {
                    Console.WriteLine("Record not found.");
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
