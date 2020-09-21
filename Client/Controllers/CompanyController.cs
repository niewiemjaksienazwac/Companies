using Newtonsoft.Json;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using CompanyService = PresentationLayer.WcfServiceReference.CompanyServiceClient;

namespace PresentationLayer.Controllers
{
    public class CompanyController : Controller
    {
        CompanyService _companyService;
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public ActionResult Index()
        {           
            var companies = JsonConvert.DeserializeObject<List<CompanyModel>>(_companyService.GetCompaniesJson());

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
            var validationMessage = JsonConvert.DeserializeObject<ValidationModel>(_companyService.ValidateCompany(companyJson));
            TempData["showSaveButton"] = validationMessage.isValid;

            if (validationMessage.isValid && Request.Form["Save"] != null)
            {
                _companyService.SaveCompany(companyJson);

                return RedirectToAction("Index");
            }
            ViewBag.Message = string.Join(" ", validationMessage.ValidationMessages);
            return View(company);
        }
    }
}