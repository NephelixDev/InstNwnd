using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.ProductCrud;
using System;

namespace InstNwnd.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductDb productDb;

        public ProductsController(IProductDb productDb)
        {
            this.productDb = productDb;
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = productDb.GetProducts();
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var product = productDb.GetProduct(id);
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductAddModels productAddModel)
        {
            if (ModelState.IsValid)
            {
                productDb.SaveProduct(productAddModel);
                return RedirectToAction(nameof(Index));
            }
            return View(productAddModel);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var product = productDb.GetProduct(id);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductUpdateModels productUpdateModel)
        {
            if (ModelState.IsValid)
            {
                productUpdateModel.ProductId = id;
                productDb.UpdateProduct(productUpdateModel);
                return RedirectToAction(nameof(Index));
            }
            return View(productUpdateModel);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var product = productDb.GetProduct(id);
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var productRemoveModel = new ProductRemoveModels
                {
                    ProductId = id,
                    Deleted = true,
                    DeleteDate = DateTime.Now,
                };

                productDb.RemoveProduct(productRemoveModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
