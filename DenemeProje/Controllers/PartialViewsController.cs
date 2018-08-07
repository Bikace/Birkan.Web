using DenemeProje.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DenemeProje.Controllers
{
    public class PartialViewsController : Controller
    {
        CategoryRepository cr = new CategoryRepository();
        SupplierRepository sr = new SupplierRepository();
        // GET: PartialViews
        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            return PartialView(cr.Categories());
        }
        [ChildActionOnly]
        public ActionResult ManufacturerMenu()
        {
            return PartialView(sr.Suppliers());
        }
    }
}