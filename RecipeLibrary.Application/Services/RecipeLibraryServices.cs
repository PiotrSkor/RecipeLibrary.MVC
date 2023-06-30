using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLibrary.Application.Services
{
    public class RecipeLibraryServices
    {
        public static void Create(Domain.Entities.RecipeDetails recipeDetails)
        {
            recipeDetails.EncodingName();

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
                /*recipeDetails = new Domain.Entities.RecipeDetails
                {
                    RecipeName = recipeDetails.RecipeName,
                };*/
                client.Push("RecipeLibrary/", recipeDetails);
            }
        }
    }
}
