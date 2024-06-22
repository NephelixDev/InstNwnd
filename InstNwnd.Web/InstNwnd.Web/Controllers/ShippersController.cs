using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.ShippersCrud;
using System;
using InstNwnd.Web.BL.Services;

namespace InstNwnd.Web.Controllers
{
    public class ShippersController : Controller
    {
        private readonly IShippersDb ShippersServices;

        public ShippersController(IShippersDb shippersDb)
        {
            this.ShippersServices = shippersDb;
        }

        // GET: Shippers
        public ActionResult Index()
        {
            var shippers = ShippersServices.GetShippers();
            return View(shippers);
        }

        // GET: Shippers/Details/5
        public ActionResult Details(int id)
        {
            var shipper = ShippersServices.GetShippers(id);
            return View(shipper);
        }

        // GET: Shippers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shippers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShippersAddModels shipperAddModel)
        {
            if (ModelState.IsValid)
            {
                ShippersServices.SaveShipper(shipperAddModel);
                return RedirectToAction(nameof(Index));
            }
            return View(shipperAddModel);
        }

        // GET: Shippers/Edit/5
        public ActionResult Edit(int id)
        {
            var shipper = ShippersServices.GetShippers(id);
            return View(shipper);
        }

        // POST: Shippers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShippersUpdateModels shipperUpdateModel)
        {
            if (ModelState.IsValid)
            {
                ShippersServices.UpdateShipper(shipperUpdateModel);
                return RedirectToAction(nameof(Index));
            }
            return View(shipperUpdateModel);
        }

        // GET: Shippers/Delete/5
        public ActionResult Delete(int id)
        {
            var shipper = ShippersServices.GetShippers(id);
            return View(shipper);
        }

        // POST: Shippers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var shipperRemoveModel = new ShippersRemoveModels
                {
                    ShipperID = id
                };

                ShippersServices.RemoveShipper(shipperRemoveModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
