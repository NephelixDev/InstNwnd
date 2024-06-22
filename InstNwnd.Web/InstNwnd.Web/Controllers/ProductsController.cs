using Microsoft.AspNetCore.Mvc;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.ProductCrud;
using InstNwnd.Web.Data.Entities;

namespace InstNwnd.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductDb ProductServices;

        public ProductsController(IProductDb productDb)
        {
            this .ProductServices = productDb;
        }

        public IActionResult Index()
        {
            var products = ProductServices.GetProducts();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = ProductServices.GetProducts(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductAddModels product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductServices.SaveProduct(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        public IActionResult Edit(int id)
        {
            var product = ProductServices.GetProducts(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductUpdateModels product)
        {
            if (ModelState.IsValid)
            {
                ProductServices.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
           var products = ProductServices.GetProducts(id);

            return View(products);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var RemoveProducts = new ProductRemoveModels { ProductID = id };
                this.ProductServices.RemoveProduct(RemoveProducts);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var Products = this.ProductServices.GetProducts(id);
                return View(Products);
            };
           
        }
    }
}
