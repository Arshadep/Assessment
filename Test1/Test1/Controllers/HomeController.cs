using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;
using Test1.ViewModel;
using Test1.RequestServiceReference;
using System.Data;

namespace Test1.Controllers
{
    public class HomeController : Controller
    {
        RequestServiceClient Client = new RequestServiceClient();
        public StoredContext _Context;

        public HomeController()
        {
            _Context = new StoredContext();
        }
        public ActionResult Index()
        {
           return View();
        }
        public ActionResult CreateRequest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRequest(Request model)
        {

            if (ModelState.IsValid)
            {
                model.Status = 0;
                _Context.Requests.Add(model);
                _Context.SaveChanges();

                return RedirectToAction("ApprovalWaiting", "home");

            }

            return View();
        }
        public ActionResult ApprovalWaiting()
        {
            ViewBag.Message = "Request Submitted Successfully, waiting for the approval";
            return View();
        }

       
       
        public ActionResult MyRequest()
        {
            var reqList = _Context.Requests.ToList();
            return View(reqList);
        }
        
         protected override void Dispose(bool disposing)
        {
            if (disposing)
                _Context.Dispose();
            base.Dispose(disposing);
        }
    }
}