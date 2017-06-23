using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalTermExam.Controllers
{
    public class CustomersController : Controller
    {
        Models.Model1 db = new Models.Model1();
        // GET: Customers
        public ActionResult Index()
        {
                   
            return View();
        }
        
        public ActionResult Search(Models.Customers c)
        {
            bool a = c.CompanyName == null;
            var results = db.Customers
                .Where(x => (c.CustomerID == 0) ? true : x.CustomerID == c.CustomerID)
                .Where(x => (c.CompanyName == null) ? true : x.CompanyName.Contains(c.CompanyName))
                .Where(x => (c.ContactName == null) ? true : x.ContactName.Contains(c.ContactName))
                .Where(x => (c.ContactTitle  == null) ? true : x.ContactTitle == c.ContactTitle);
            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}