using Newtonsoft.Json;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            var companies = JsonConvert.DeserializeObject<List<CompanyModel>>(_wcfService.GetCompaniesJson());

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
            var validationMessage = JsonConvert.DeserializeObject<ValidationModel>(_wcfService.ValidateCompany(companyJson));
            TempData["showSaveButton"] = validationMessage.isValid;

            if (validationMessage.isValid && Request.Form["Save"] != null)
            {
                _wcfService.SaveCompany(companyJson);

                return RedirectToAction("Index");
            }
            ViewBag.Message = string.Join(" ", validationMessage.ValidationMessages);
            return View(company);
        }
    }
}