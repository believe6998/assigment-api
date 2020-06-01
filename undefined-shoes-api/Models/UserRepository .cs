using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace undefined_shoes_api.Models
{
    public class UserRepository: IDisposable
    {
        MyDatabaseContext db = new MyDatabaseContext();
        //This method is used to check and validate the user credentials
        public User ValidateUser(string username, string password)
        {
            return db.Users.FirstOrDefault(user =>
                user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}