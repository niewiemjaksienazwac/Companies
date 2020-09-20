using Newtonsoft.Json;
using PresentationLayer.Models;
using Repository;
using ServicesLayer.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicesLayer
{
    public class WcfService : IWcfService
    {
        public string GetCompaniesJson()
        {
            var existingCompanies = RepositoryClass.GetAllCompanies();

            return JsonConvert.SerializeObject(existingCompanies);
        }

        public string ValidateCompany(string companyJson)
        {           
            var newCompany = JsonConvert.DeserializeObject<CompanyEntity>(companyJson); 
            var companyValidation = CompanyValidator.Validate(newCompany, RepositoryClass.GetAllCompanies());

            return JsonConvert.SerializeObject(companyValidation);
        }

        public void SaveCompany(string companyJson)
        {
            var newCompany = JsonConvert.DeserializeObject<CompanyEntity>(companyJson);
            AssignEntityId(ref newCompany);            
            RepositoryClass.AddCompany(newCompany);
        }

        private void AssignEntityId(ref CompanyEntity newCompany)
        {
            newCompany.Id = Guid.NewGuid().ToString();
        }
    }
}
