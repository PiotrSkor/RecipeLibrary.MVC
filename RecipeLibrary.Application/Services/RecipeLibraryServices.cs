using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeLibrary.Domain.Entities;

namespace RecipeLibrary.Application.Services
{
    public class RecipeLibraryServices
    {
        public static void Create(RecipeDetails recipeDetails)
        {
            if (recipeDetails.RecipeName != null)
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
    }
}
