using DenemeProje.Models;
using DenemeProje.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DenemeProje.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        ProductRepository pr = new ProductRepository();

        // GET: Product

        public ActionResult ProductList()
        {
            return View(pr.Products());
        }
        public ActionResult ProductByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(pr.ProductsByCategory(id));
        }

        public ActionResult ProductBySuppliers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(pr.ProductsBySuppliers(id));
        }

        public ActionResult ProductAdd()
        {
            ViewBag.Categories = GetCategories();
            ViewBag.Suppliers = GetSuppliers();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product entity)
        {
            ViewBag.Categories = GetCategories();
            ViewBag.Suppliers = GetSuppliers();
            if (ModelState.IsValid)
            {
                pr.ProductInsert(entity);
                return RedirectToAction("ProductList");

            }
            else
            {
                ModelState.AddModelError("", "Hata oluştu!");
            }
            return View(entity);
        }

        public ActionResult ProductDelete(int id)
        {

            Product _product = db.Products.Find(id);
            return View(_product);

        }

        [HttpPost]
        public ActionResult ProductDelete(Product entity)
        {

            if (ModelState.IsValid)
            {
                pr.ProductDelete(entity.ProductID);
                return RedirectToAction("ProductList");
            }
            else
            {
                ModelState.AddModelError("", "Hata Oluştu");
            }
            return View(entity);
        }
        public ActionResult ProductUpdate(int id)
        {
            ViewBag.Categories = GetCategories();
            ViewBag.Suppliers = GetSuppliers();


            Product _product = db.Products.Find(id);
            return View(_product);

        }

        [HttpPost]
        public ActionResult ProductUpdate(Product entity)
        {
            ViewBag.Categories = GetCategories();
            ViewBag.Suppliers = GetSuppliers();
            if (ModelState.IsValid)
            {
                pr.ProductUpdate(entity);
                return RedirectToAction("ProductList");
            }
            else
            {
                ModelState.AddModelError("", "Hata Oluştu");
            }
            return View(entity);
        }

        private List<SelectListItem> GetSuppliers()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in db.Suppliers)
            {
                items.Add(new SelectListItem
                {
                    Text = item.CompanyName,
                    Value = item.SupplierID.ToString()
                });
            }
            items.Insert(0, new SelectListItem { Text = "Seçiniz...", Value = "0" });
            return items;

        }

        private List<SelectListItem> GetCategories()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in db.Categories)
            {
                items.Add(new SelectListItem
                {
                    Text = item.CategoryName,
                    Value = item.CategoryID.ToString()
                });
            }
            items.Insert(0, new SelectListItem { Text = "Seçiniz...", Value = "0" });
            return items;

        }
    }
}