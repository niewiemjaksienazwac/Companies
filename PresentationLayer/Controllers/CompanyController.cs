using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class CompanyController : Controller
    {
        WcfServiceReference.WcfServiceClient _wcfService;        
        public ActionResult Index()
        {
            if(_wcfService == null)
            {
                _wcfService = new WcfServiceReference.WcfServiceClient();
            }

            var companies = _wcfService.GetCompanies();            

            return View(companies);
        }
    }
}