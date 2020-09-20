using Microsoft.SqlServer.Server;
using PresentationLayer.WcfServiceReference;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Validators
{
    public static class CompanyValidator
    {
        public static CompanyValidationResponse Validate(CompanyEntity newCompany, List<CompanyEntity> existingCompanies)
        {
            var companyValidation = new CompanyValidationResponse();

            ValidateNullOrEmptyFields(ref companyValidation, newCompany);
            //ValidateNip(newCompany);
            //ValidatePhoneNumber(newCompany); // some crazy regex
            // some more fancy validations
            ValidateForDuplicates(ref companyValidation, newCompany, existingCompanies);

            return companyValidation;
        }

        private static void ValidateForDuplicates(ref CompanyValidationResponse companyValidation, CompanyEntity newCompany, List<CompanyEntity> existingCompanies)
        {
            if (!companyValidation.isValid)
            {
                return;
            }

            if(existingCompanies.Any(c => c.Nip.Equals(newCompany.Nip)))
            {
                companyValidation.isValid = false;
                companyValidation.ValidationMessages.Add("company with this NIP already exist!");
            }
            if (existingCompanies.Any(c => c.Phone.Equals(newCompany.Phone)))
            {
                companyValidation.isValid = false;
                companyValidation.ValidationMessages.Add("company with this Phone number already exist!");
            }
        }

        private static void ValidateNullOrEmptyFields(ref CompanyValidationResponse companyValidation, CompanyEntity newCompany)
        {
            if (IsNullOrEmpty(newCompany.Name))
            {
                companyValidation.isValid = false;
                companyValidation.ValidationMessages.Add("field 'Name' is required!");
            }
            if (IsNullOrEmpty(newCompany.Address))
            {
                companyValidation.isValid = false;
                companyValidation.ValidationMessages.Add("field 'Address' is required!");
            }
            if (IsNullOrEmpty(newCompany.Www))
            {
                companyValidation.isValid = false;
                companyValidation.ValidationMessages.Add("field 'Internet Domain' is required!");
            }
            if (IsNullOrEmpty(newCompany.Nip))
            {
                companyValidation.isValid = false;
                companyValidation.ValidationMessages.Add("field 'NIP' is required!");
            }
            if (IsNullOrEmpty(newCompany.Phone))
            {
                companyValidation.isValid = false;
                companyValidation.ValidationMessages.Add("field 'Phone Number' is required!");
            }
        }

        private static bool IsNullOrEmpty(string text)
        {
            return (string.IsNullOrEmpty(text) || text.ToUpper().Equals("NULL"));
        }
    }

    public class CompanyValidationResponse
    {
        public bool isValid { get; set; }

        public List<string> ValidationMessages { get; set; }

        public CompanyValidationResponse()
        {
            isValid = true;
            ValidationMessages = new List<string>();
        }
    }
}
