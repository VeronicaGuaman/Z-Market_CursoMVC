using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Z_Market2.Models;

namespace Z_Market2.Controllers
{
    public class ProductsController : Controller
    {
        private Z_Market2Context db = new Z_Market2Context();
        Category Category = new Category();

        // GET: Products
        public ActionResult Index()
        {
            //List<Category> CategoryList = db.Categories.ToList();
            //ViewBag.CategoryList = new SelectList(CategoryList, "CategoryID", "Name");
            var products = db.Products.Include(p => p.Subcategories);
            return View(products.ToList());
        }
        public JsonResult GetSubcategoryList(int CategoryID )
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Subcategory> SubcategoryList = db.Subcategories.Where(x => x.CategoryID == CategoryID).ToList();
         return Json(SubcategoryList, JsonRequestBehavior.AllowGet);
        }
        //GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            List<Category> CategoryList = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(CategoryList, "CategoryID", "Name");

            //ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.SubcategoryList = new SelectList(db.Subcategories, "SubcategoryID", "Name");
            return View();
        }

        // POST: Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,SubcategoryID,Descripcion,Price,LastBuy,Stock,Remarks")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubcategoryID = new SelectList(db.Subcategories, "SubcategoryID", "Name", product.SubcategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubcategoryID = new SelectList(db.Subcategories, "SubcategoryID", "Name", product.SubcategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,SubcategoryID,Descripcion,Price,LastBuy,Stock,Remarks")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubcategoryID = new SelectList(db.Subcategories, "SubcategoryID", "Name", product.SubcategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
