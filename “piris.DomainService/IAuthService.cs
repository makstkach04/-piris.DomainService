using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace _piris.DomainService
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        bool UserRegistration(UserRegistration userObj);
        [OperationContract]
        bool UserAuth(UserRegistration userObj);
    }
}
