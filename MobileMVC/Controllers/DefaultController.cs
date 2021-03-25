using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileMVC.Models;

namespace MobileMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        masterEntities db = new masterEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Product prod)
        {
            prod.Pname = Request.Form["txtname"];
            prod.PDesc = Request.Form["txtdesc"];
            prod.PManu = Request.Form["txtdmanu"];
            prod.Price = Convert.ToDecimal(Request.Form["txtsalary"]);
            prod.Pcat = Request.Form["ddlcat"];

            db.Products.Add(prod);
            int res = db.SaveChanges();
            if (res > 0)
                ModelState.AddModelError("", "new product inserted");
            return RedirectToAction("GetProduct");
        }
        public ActionResult GetProduct()
        {
            var data = db.Products.ToList();
            return View(data);//model binding

        }
    }
}