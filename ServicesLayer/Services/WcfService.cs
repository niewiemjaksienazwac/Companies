using DataObjectLayer.DataTransferObjects;
using PresentationLayer.Models;
using ServicesLayer.Services;
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
        CompanyService _companyService;

        public List<CompanyModel> GetCompanies()
        {
            var companyList = new List<CompanyDto>
            {
                new CompanyDto() {Id = "1", InternetAddress = "www1", Name = "companny1", NipNumber = "123213", PhoneNumber = "+11", PhysicalAddress = "address1"},
                new CompanyDto() {Id = "2", InternetAddress = "www2", Name = "companny2", NipNumber = "23423413", PhoneNumber = "+22", PhysicalAddress = "address2"},
                new CompanyDto() {Id = "3", InternetAddress = "www3", Name = "companny3", NipNumber = "12323453", PhoneNumber = "+33", PhysicalAddress = "address3"},
            };

            if(_companyService == null)
            {
                _companyService = new CompanyService();
            }

            var companies = _companyService.Map(companyList);

            return companies.ToList();
        }

        public void Receive(CompanyModel company)
        {
            //validation
            //var isValid = CompanyValidator.Validate(company);

        }

        public void Receive(string companyJson)
        {
            //validation
            

        }

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");s
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
