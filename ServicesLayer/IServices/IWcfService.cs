using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicesLayer
{
    [ServiceContract]
    public interface IWcfService
    {
        [OperationContract]
        public string GetCompaniesJson();

        [OperationContract]
        public string ValidateCompany(string companyJson);
    }
}
