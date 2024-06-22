using Microsoft.AspNetCore.Mvc;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.SuppliersCrud;
using InstNwnd.Web.Data.Models.SupplierCrud;

namespace InstNwnd.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliersDb suppliersServices;

        public SuppliersController(ISuppliersDb suppliersDb)
        {
            this.suppliersServices = suppliersDb;
        }

        public IActionResult Index()
        {
            var suppliers = suppliersServices.GetSuppliers(); // Obtener la lista de proveedores desde la base de datos
            var supplierModels = suppliers.Select(s => new SupplierGetModels
            {
                SupplierID = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                // Asegúrate de mapear todas las propiedades necesarias
            }).ToList();

            return View(supplierModels); // Enviar el modelo correcto a la vista
        }

        public IActionResult Details(int id)
        {
            var supplier = suppliersServices.GetSuppliers(id); // Cambiado a GetSupplier
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SuppliersAddModels supplier) // Cambiado a SuppliersAddModels
        {
            if (ModelState.IsValid)
            {
                suppliersServices.SaveSupplier(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        public IActionResult Edit(int id)
        {
            var supplier = suppliersServices.GetSuppliers(id); // Cambiado a GetSupplier
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SuppliersUpdateModels supplier)
        {
            if (ModelState.IsValid)
            {
                suppliersServices.UpdateSupplier(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        public IActionResult Delete(int id)
        {
            var supplier = suppliersServices.GetSuppliers(id); // Cambiado a GetSupplier
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var supplierRemoveModel = new SuppliersRemoveModels
                {
                    SupplierID = id
                };

                suppliersServices.RemoveSupplier(supplierRemoveModel); // Cambiado a RemoveSupplier con modelo
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
