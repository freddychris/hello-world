using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ironman.Models;
using System.Net;

namespace ironman.Controllers
{
    public class marvelController : Controller
    {
        //
        // GET: /marvel/
        public ActionResult Home()
        {
            return View();
        }
    [HttpGet]
        public ActionResult one()
        {
            return View();
        }
        [HttpPost]
    public ActionResult one(Table obj)
    {
        if (ModelState.IsValid)
        {
            captionamericaEntities db = new captionamericaEntities();
            db.Tables.Add(obj);
            db.SaveChanges();
            return RedirectToAction("two");
        }
        else
        {
            return View();
        }
        return View(obj);
    }
        [HttpGet]
        public ActionResult two()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult two(Table objUser)
        {
            if (ModelState.IsValid)
            {
                using (captionamericaEntities db = new captionamericaEntities())
                {
                    var obj = db.Tables.Where(model => model.User_Id.Equals(objUser.User_Id) && model.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Id"] = obj.Id.ToString();
                        Session["User Id"] = obj.User_Id.ToString();
                        return RedirectToAction("Exits");
                    }
                }
            }
            return View(objUser);
        }
        public ActionResult Exits()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("News");
            }
        }
	}
}