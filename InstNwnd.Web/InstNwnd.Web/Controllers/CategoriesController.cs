using InstNwnd.Web.BL.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.CategoriesCrud;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstNwnd.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesDb categoriesService;

        public CategoriesController(ICategoriesDb categoriesDb)
        {
            this.categoriesService = categoriesDb;
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            var categories = this.categoriesService.GetCategories();
            return View(categories);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var category = this.categoriesService.GetCategory(id);
            return View(category);
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriesSaveModels categoriesSave)
        {
            try
            {
                this.categoriesService.SaveCategory(categoriesSave);
                return RedirectToAction(nameof(Index));
            }
            catch (CategoriesException exp)
            {
                Console.WriteLine(exp.Message);
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = this.categoriesService.GetCategory(id);
            var updateCategory = new CategoriesUpdateModels
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            };
            return View(updateCategory);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriesUpdateModels updateModels)
        {
            try
            {
                this.categoriesService.UpdateCategory(updateModels);
                return RedirectToAction(nameof(Index));
            }
            catch (CategoriesException exp)
            {
                Console.WriteLine(exp.Message);
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = this.categoriesService.GetCategory(id);
            return View(category);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var categoryRemoveModel = new CategoriesRemoveModels { CategoryID = id };
                this.categoriesService.RemoveCategory(categoryRemoveModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var category = this.categoriesService.GetCategory(id);
                return View(category);
            }
        }
    }
}
