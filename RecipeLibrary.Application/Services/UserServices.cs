using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using RecipeLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLibrary.Application.Services
{
    public class UserServices
    {
     
        public static async void Register(User user)
        {

            var auth = FirebaseAuth.DefaultInstance;

            try 
            {
                var userr = await auth.CreateUserAsync(new UserRecordArgs
                {
                    Email = user.Email,
                    Password = user.Password
                });
            }
            catch (FirebaseAuthException ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public static bool CheckPassword(User user)
        {
            if (user.Password != user.ConfirmPassword)
            {
                return false;
            }
            return true;
        }

    }
}
