using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using _piris.DomainService.DbContext;

namespace _piris.DomainService
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        bool UserRegistration(store_users userObj);
        [OperationContract]
        bool UserAuth(store_users userObj);
    }
}
