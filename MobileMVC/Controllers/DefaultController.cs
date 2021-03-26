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
        //retrieve product data from db based on condition
        [HttpGet]
        public ActionResult GetProductByPrice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetProductByPrice(string cat, decimal price = 0)
        {
            cat = Request.Form["category"];
            price = Convert.ToDecimal(Request.Form["price"]);
            var query = from t in db.Products
                        where t.Pcat == cat && t.Price > price
                        select t;
            if (query.Count() == 0)
            {
                ModelState.AddModelError("", "No data found");
                return View();
            }
            else
            {//will pass data from controller to view
                Session["data"] = query;
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var data = db.Products.Where(x => x.ProductID == id).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult UpdateProduct()
        {
            int id = Convert.ToInt32(Request.Form["pid"]);
            var olddata = db.Products.Where(x => x.ProductID == id).SingleOrDefault();
            var newname = Request.Form["pname"];
            var newdesc = Request.Form["pdesc"];
            var newmanu = Request.Form["pmanu"];
            var newprice = Convert.ToDecimal(Request.Form["price"]);
            var newcat = Request.Form["pcat"];
            olddata.Pname = newname;
            olddata.PDesc = newdesc;
            olddata.Pcat = newcat;
            olddata.PManu = newmanu;
            olddata.Price = newprice;
            var res = db.SaveChanges();
            if (res > 0)
                return RedirectToAction("GetProduct");//hyperlink to getproduct
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult DeleteProduct(int id)
        {
            var data = db.Products.Where(x => x.ProductID == id).SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult DeleteProduct()
        {
            int id = Convert.ToInt32(Request.Form["pid"]);
            var delrow = db.Products.Where(x => x.ProductID == id).SingleOrDefault();
            db.Products.Remove(delrow);
            var res = db.SaveChanges();
            if (res > 0)
                return RedirectToAction("GetProduct");//hyperlink to getproduct
            return RedirectToAction("GetProduct");

        }
        [HttpGet]
        public ActionResult CategorySelect()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategorySelect(string cat)
        {
            cat = Request.Form["category"];
            var query = from t in db.Products
                        where t.Pcat == cat
                        select t;
            if (query.Count() == 0)
            {
                ModelState.AddModelError("", "No data found");
                return View();
            }
            else
            {//will pass data from controller to view
                Session["data"] = query;
            }
            return View();
        }

    }
}