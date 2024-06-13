using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.CategoriesCrud;
using System;

namespace InstNwnd.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesDb categoriesDb;

        public CategoriesController(ICategoriesDb categoriesDb)
        {
            this.categoriesDb = categoriesDb;
        }

        // GET: Categories
        public ActionResult Index()
        {
            var categories = categoriesDb.GetCategories();
            return View(categories);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            var category = categoriesDb.GetCategories(id);
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersSaveModels CategoriesSaveModels)
        {
            if (ModelState.IsValid)
            {
                categoriesDb.SaveCategories(CategoriesSaveModels);
                return RedirectToAction(nameof(Index));
            }
            return View(CategoriesSaveModels);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            var category = categoriesDb.GetCategories(id);
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriesUpdateModels categoriesUpdateModels)
        {
            if (ModelState.IsValid)
            {
                categoriesUpdateModels.CategoryId = id;
                categoriesDb.UpdateCategories(categoriesUpdateModels);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriesUpdateModels);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            var category = categoriesDb.GetCategories(id);
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var categoryRemoveModel = new CategoriesRemoveModels
                {
                    CategoryId = id,
                    Deleted = true,
                    DeleteDate = DateTime.Now,
                };

                categoriesDb.RemoveCategories(categoryRemoveModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
