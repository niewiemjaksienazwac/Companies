using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class CompanyModel
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhysicalAddress { get; set; }
        public string CompanyInternetAddress { get; set; }
        public string CompanyNipNumber { get; set; }
        public string CompanyPhoneNumber { get; set; }
    }
}
