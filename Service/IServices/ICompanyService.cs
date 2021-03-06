﻿using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicesLayer
{
    [ServiceContract]
    public interface ICompanyService
    {
        [OperationContract]
        public string GetCompaniesJson();

        [OperationContract]
        public string ValidateCompany(string companyJson);

        [OperationContract]
        public void SaveCompany(string companyJson);
    }
}
