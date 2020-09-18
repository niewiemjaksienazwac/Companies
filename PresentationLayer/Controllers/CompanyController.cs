using Newtonsoft.Json;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wcf = PresentationLayer.WcfServiceReference.WcfServiceClient;

namespace PresentationLayer.Controllers
{
    public class CompanyController : Controller
    {
        Wcf _wcfService;

        public CompanyController(Wcf wcfService)
        {
            _wcfService = wcfService;
        }

        public ActionResult Index()
        {
            //if(_wcfService == null)
            //{
            //    _wcfService = new WcfServiceReference.WcfServiceClient();
            //}

            var companies = _wcfService.GetCompanies();            

            return View(companies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WcfServiceReference.CompanyModel company)
        {
            //if (_wcfService == null)
            //{
            //    _wcfService = new WcfServiceReference.WcfServiceClient();
            //}

            _wcfService.Receive(company);

            var companyJson = JsonConvert.SerializeObject(company);

            var deserialized = JsonConvert.DeserializeObject<CompanyModel>(companyJson);

            return RedirectToAction("Index");
        }
    }
}