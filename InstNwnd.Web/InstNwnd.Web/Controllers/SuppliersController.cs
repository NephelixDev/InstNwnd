using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InstNwnd.Web.Data.Interfaces;
using System;
using InstNwnd.Web.Data.Models.SuppliersCrud;

namespace InstNwnd.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliersDb suppliersDb;

        public SuppliersController(ISuppliersDb suppliersDb)
        {
            this.suppliersDb = suppliersDb;
        }

        // GET: Suppliers
        public ActionResult Index()
        {
            var suppliers = suppliersDb.GetSuppliers();
            return View(suppliers);
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int id)
        {
            var supplier = suppliersDb.GetSupplier(id);
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuppliersAddModels supplierAddModel)
        {
            if (ModelState.IsValid)
            {
                suppliersDb.SaveSupplier(supplierAddModel);
                return RedirectToAction(nameof(Index));
            }
            return View(supplierAddModel);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int id)
        {
            var supplier = suppliersDb.GetSupplier(id);
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuppliersUpdateModels supplierUpdateModel)
        {
            if (ModelState.IsValid)
            {
                supplierUpdateModel.SupplierId = id;
                suppliersDb.UpdateSupplier(supplierUpdateModel);
                return RedirectToAction(nameof(Index));
            }
            return View(supplierUpdateModel);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int id)
        {
            var supplier = suppliersDb.GetSupplier(id);
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var supplierRemoveModel = new SuppliersRemoveModels
                {
                    SupplierId = id
                };

                suppliersDb.RemoveSupplier(supplierRemoveModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
