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
            string existingCompaniesJson = JsonConvert.SerializeObject(existingCompanies);

            return existingCompaniesJson;
        }

        public string ValidateCompany(string companyJson)
        {           
            var newCompany = JsonConvert.DeserializeObject<CompanyEntity>(companyJson); // would be replaced with some actual logic

            var companyValidation = CompanyValidator.Validate(newCompany, RepositoryClass.GetAllCompanies());
            if (companyValidation.isValid)
            {
                newCompany.Id = Guid.NewGuid().ToString();
                RepositoryClass.AddCompany(newCompany);
            }
            else
            {
                return string.Join(" ", companyValidation.ValidationMessages);
            }

            return string.Empty;
        }
    }
}
