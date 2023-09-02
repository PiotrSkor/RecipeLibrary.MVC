using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;
using FirebaseAdmin.Auth;

namespace RecipeLibrary.Application.Services
{
    public class ConectToFirebase
    {
        public static IFirebaseClient ConectToFirebaseMethod()
        {

            string authSecret = "AgmJVhSXQ3hNPwu6Fti6QstWbKZeB4cLLxGIrQqK"; //StringHelper.GetAppSettings(Constants.AppSetingTypes.Firebase, "AuthSecret");
            string basePath = "https://recipelibrary-d8e55-default-rtdb.europe-west1.firebasedatabase.app/";//StringHelper.GetAppSetings(Constants.AppSetingTypes.Firebase, "BasePath");

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath,
            };

            
            return new FirebaseClient(config);
        }
    }
}
