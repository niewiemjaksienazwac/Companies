using Microsoft.SqlServer.Server;
using PresentationLayer.WcfServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Validators
{
    public static class CompanyValidator
    {
        public static CompanyValidationResponse Validate(CompanyModel company)
        {
            return new CompanyValidationResponse();
        }

        internal static object Validate(PresentationLayer.Models.CompanyModel company)
        {
            throw new NotImplementedException();
        }
    }

    public class CompanyValidationResponse
    {
        public bool isValid { get; set; }

        public string ValidationMessage { get; set; }
    }
}
