using InstNwnd.Web.Data.DbObjects;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.EmployeeCrud;
using InstNwnd.Web.Data.Models.EmployeesCrud;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InstNwnd.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesDb employeesServices;

        public EmployeesController(IEmployeesDb employeesDb)
        {
            this.employeesServices = employeesDb;
        }


        public IActionResult Index()
        {

            var employees = employeesServices.GetEmployees(); 
            return View(employees); 
        }


        public IActionResult Details(int id)
        {
            var employee = this.employeesServices.GetEmployee(id); 
            return View(employee); 
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeesSaveModels save)
        {
            try
            {
                save.BirthDate = DateTime.Now;
                employeesServices.SaveEmployee(save);
                return RedirectToAction(nameof(Index));
            }
            catch (EmployeesDbException exp)
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = employeesServices.GetEmployee(id);
            var updateEmployees = new EmployeesUpdateModels();
            {
                updateEmployees.EmployeeID = employee.EmployeeID;
                updateEmployees.FirstName = employee.FirstName;
                updateEmployees.LastName = employee.LastName;
                updateEmployees.Title = employee.Title;
                updateEmployees.BirthDate = employee.BirthDate;
                updateEmployees.Address = employee.Address;
                updateEmployees.City = employee.City;
                updateEmployees.Region = employee.Region;
                updateEmployees.PostalCode = employee.PostalCode;
                updateEmployees.Country = employee.Country;
                updateEmployees.HomePhone = employee.HomePhone;
                updateEmployees.Extension = employee.Extension;
                updateEmployees.Photo = employee.Photo;
                updateEmployees.Notes = employee.Notes;
                updateEmployees.ReportsTo = employee.ReportsTo;
                updateEmployees.PhotoPath = employee.PhotoPath;
            }
            return View(updateEmployees);
        }

        // GET: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeesUpdateModels employeesUpdate)
        {
            try
            {
                employeesServices.UpdateEmployee(employeesUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                    return View();
            }
           
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = employeesServices.GetEmployee(id);
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var removeModel = new EmployeesRemoveModels { EmployeeID = id };
                employeesServices.RemoveEmployee(removeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var employee = employeesServices.GetEmployee(id);
                return View();
            }
        }
    }
}
