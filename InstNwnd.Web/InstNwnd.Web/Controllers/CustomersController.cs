using InstNwnd.Web.BL.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.CustomersCrud;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstNwnd.Web.Controllers
{
    public class CustomersController : Controller
    {

        private readonly ICustomersDb customersService;

        public CustomersController(ICustomersDb customersDb)
        {
            this.customersService = customersDb;
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            var customers = this.customersService.GetCustomers();
            return View(customers);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(string id)
        {
            var customer = this.customersService.GetCustomers(id);
            return View(customer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersSaveModels customersSave)
        {
            try
            {
                this.customersService.SaveCustomer(customersSave);
                return RedirectToAction(nameof(Index));
            }
            catch (CustomerServicesException exp)
            {
                Console.WriteLine(exp.Message);
                return View();
            }

        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(string id)
        {
            var cust = this.customersService.GetCustomers(id);
            var updateCustomers = new CustomersUpdateModels
            {
                CustomerId = cust.CustomerId,
                CompanyName = cust.CompanyName,
                ContactName = cust.ContactName,
                ContactTitle = cust.ContactTitle,
                Address = cust.Address,
                City = cust.City,
                Region = cust.Region,
                PostalCode = cust.PostalCode,
                Country = cust.Country,
                Phone = cust.Phone,
                Fax = cust.Fax
            };
            return View(updateCustomers);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomersUpdateModels updateModels)
        {
            try
            {
                this.customersService.UpdateCustomer(updateModels);
                return RedirectToAction(nameof(Index));
            }
            catch(CustomerServicesException exp)
            {
                Console.WriteLine(exp.Message);
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(string id)
        {
            var customer = customersService.GetCustomers(id);
            return View(customer);
        }

        // POST: CustomersController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {

            try

            {
                var customer = new CustomersRemoveModels { CustomerId = id };
                this.customersService.RemoveCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var customer = customersService.GetCustomers(id);
                return View(customer);
            }
        }
    }
}
