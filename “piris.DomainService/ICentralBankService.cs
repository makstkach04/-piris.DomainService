using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _piris.DomainService
{
    [ServiceContract]
    public interface ICentralBankService
    {
        [OperationContract]
        ConverterObject ConvertValue(double value, string
        currencyValue);
    }
}
