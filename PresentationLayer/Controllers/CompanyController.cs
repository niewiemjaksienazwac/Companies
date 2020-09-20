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
            //var companies = _wcfService.GetCompanies();

            var companiesJson = _wcfService.GetCompaniesJson();

            var companies = JsonConvert.DeserializeObject<List<CompanyModel>>(companiesJson);

            return View(companies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CompanyModel company)
        {

            var companyJson = JsonConvert.SerializeObject(company);

            var deserialized = JsonConvert.DeserializeObject<CompanyModel>(companyJson);

            _wcfService.Receive(companyJson);

            return RedirectToAction("Index");
        }
    }
}