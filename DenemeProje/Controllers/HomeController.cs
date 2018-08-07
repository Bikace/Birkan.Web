using DenemeProje.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DenemeProje.Controllers
{
    public class HomeController : Controller
    {
        ProductRepository pr = new ProductRepository();
        // GET: Home

        public ActionResult Index()
        {
            return View(pr.SixProduct());
        }
    }
}