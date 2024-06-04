using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstNwnd.Web.Controllers
{
    public class Order_Details : Controller
    {
        // GET: Order_Details
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order_Details/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order_Details/Create
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

        // GET: Order_Details/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order_Details/Edit/5
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

        // GET: Order_Details/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order_Details/Delete/5
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
