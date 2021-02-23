using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Z_Market2.Models;
using Z_Market2.ViewModels;

namespace Z_Market2.Controllers
{
    public class OrderSupplierController : Controller
    {
        private Z_Market2Context db = new Z_Market2Context();
        // GET: Orders
        public ActionResult NewOrders()
        {
            var supplierproduct = new SupplierProduct();
            supplierproduct.Supplier = new Supplier();
            supplierproduct.Products = new List<Product>();
            Session["orderView"] = supplierproduct;

            var list = db.Suppliers.ToList();
            list.Add(new Supplier { SupplierID = 0, Name = "[Selecct a Supplier]" });
            list = list.OrderBy(c => c.Name).ToList();
            ViewBag.SupplierID = new SelectList(list, "SupplierID", "Name");

            var list1 = db.Products.ToList();
            list1.Add(new ProductOrder { ProductID = 0, Descripcion = "[Select a Product...]" });
            list1 = list1.OrderBy(p => p.Descripcion).ToList();
            ViewBag.ProductID = new SelectList(list1, "ProductID", "Descripcion");
            PopulateAssignedProductData(supplierproduct);

            return View(supplierproduct);
        }

        //-------------------------------------product
        private void PopulateAssignedProductData(SupplierProduct supplierproduct)
        {
            var allProduct = db.Products;
            var order = new HashSet<int>(supplierproduct.Products.Select(b => b.ProductID));
            var viewModelAvailable = new List<SupplierProductVM>();
            var viewModelSelected = new List<SupplierProductVM>();
            foreach (var product in allProduct)
            {
                if (order.Contains(product.ProductID))
                {
                    viewModelSelected.Add(new SupplierProductVM
                    {
                        ProductID = product.ProductID,
                        Descripcion = product.Descripcion,
                        //Assigned = true
                    });
                }
                else
                {
                    viewModelAvailable.Add(new SupplierProductVM
                    {
                        ProductID = product.ProductID,
                        Descripcion = product.Descripcion,
                        //Assigned = false
                    });
                }
            }

            ViewBag.selOpts = new MultiSelectList(viewModelSelected, "ProductID", "Descripcion");
            ViewBag.availOpts = new MultiSelectList(viewModelAvailable, "ProductID", "Descripcion");
        }

        //---------
        //product

        [HttpPost]
        public ActionResult NewOrders(SupplierProduct supplierproduct, string[] selectedOptions)
        {
            if (selectedOptions != null)
            {
                supplierproduct.Products = new List<Product>();
                foreach (var product in selectedOptions)
                {
                    var productToAdd = db.Products.Find(int.Parse(product));
                    supplierproduct.Products.Add(productToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                db.SupplierProducts.Add(supplierproduct);
                db.SaveChanges();
                return RedirectToAction("NewOrders");
            }


            PopulateAssignedProductData(supplierproduct);
            return View(supplierproduct);

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