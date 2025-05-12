using _piris.DomainService.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace _piris.DomainService
{
    public class AuthService : IAuthService
    {
        private static DatabaseService _databaseService = new
        DatabaseService();
        public bool UserAuth(store_users userObj)
        {
        var res =
        _databaseService.GetUserByUserName(userObj.userName);
            if (res == null)
            {
                return false;
            }
            if (userObj.userPassword == res.userPassword)
            {
                return true;
            }
            return true;
        }
        public bool UserRegistration(store_users userObj)
        {
            store_users dbUser = new store_users();
            dbUser.userName = userObj.userName;
            dbUser.userPassword = userObj.userPassword;
            var res = _databaseService.CreateUser(dbUser);
            return res;
        }
    }
}
