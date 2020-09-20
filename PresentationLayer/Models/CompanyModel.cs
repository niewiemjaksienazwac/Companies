using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class CompanyModel
    {
        public string Id { get; set; }
        [Display(Name = "Name:")]
        public string Name { get; set; }
        [Display(Name = "Address:")]
        public string Address { get; set; }
        [Display(Name = "Internet Domain:")]
        public string Www { get; set; }
        [Display(Name = "NIP:")]
        public string Nip { get; set; }
        [Display(Name = "Phone Number:")]
        public string Phone { get; set; }
    }
}
