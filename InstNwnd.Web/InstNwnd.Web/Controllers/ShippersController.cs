using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstNwnd.Web.Controllers
{
    public class ShippersController : Controller
    {
        // GET: ShippersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShippersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShippersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShippersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShippersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShippersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShippersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
