using InstNwnd.Web.BL.Exceptions;
using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.EmployeesCrud;
using System.Collections.Generic;
using System.Linq;

namespace InstNwnd.Web.Data.DbObjects
{
    public class EmployeesDb : IEmployeesDb
    {
        private readonly InstNwndContext context;

        public EmployeesDb(InstNwndContext context)
        {
            this.context = context;
        }

        public EmployeesModels GetEmployee(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new EmployeesException("Este empleado no se encuentra registrado.");
            }

            EmployeesModels employeeModel = new EmployeesModels()
            {
                EmployeeId = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate, 
                HireDate = employee.HireDate, 
                Address = employee.Address,
                City = employee.City,
                Region = employee.Region,
                PostalCode = employee.PostalCode,
                Country = employee.Country,
                HomePhone = employee.HomePhone,
                Extension = employee.Extension,
                Photo = employee.Photo,
                Notes = employee.Notes,
                ReportsTo = employee.ReportsTo,
                PhotoPath = employee.PhotoPath
            };

            return employeeModel;
        }

        public List<EmployeesModels> GetEmployees()
        {
            return this.context.Employees.Select(e => new EmployeesModels()
            {
                EmployeeId = e.Id,
                LastName = e.LastName,
                FirstName = e.FirstName,
                Title = e.Title,
                TitleOfCourtesy = e.TitleOfCourtesy,
                BirthDate = e.BirthDate,
                HireDate = e.HireDate,
                Address = e.Address,
                City = e.City,
                Region = e.Region,
                PostalCode = e.PostalCode,
                Country = e.Country,
                HomePhone = e.HomePhone,
                Extension = e.Extension,
                Photo = e.Photo,
                Notes = e.Notes,
                ReportsTo = e.ReportsTo,
                PhotoPath = e.PhotoPath
            }).ToList();
        }

        public void RemoveEmployee(EmployeesRemoveModels removeEmployee)
        {
            Employees employeeToDelete = this.context.Employees.Find(removeEmployee.EmployeeId);

            if (employeeToDelete == null)
            {
                throw new EmployeesDbException("Este empleado no se encuentra registrado.");
            }

            employeeToDelete.Deleted = removeEmployee.Deleted;

            this.context.Employees.Update(employeeToDelete);
            this.context.SaveChanges();
        }

        public void SaveEmployee(EmployeesAddModels saveEmployee)
        {
            Employees employee = new Employees()
            {
                LastName = saveEmployee.LastName,
                FirstName = saveEmployee.FirstName,
                Title = saveEmployee.Title,
                TitleOfCourtesy = saveEmployee.TitleOfCourtesy,
                BirthDate = saveEmployee.BirthDate,
                HireDate = saveEmployee.HireDate,
                Address = saveEmployee.Address,
                City = saveEmployee.City,
                Region = saveEmployee.Region,
                PostalCode = saveEmployee.PostalCode,
                Country = saveEmployee.Country,
                HomePhone = saveEmployee.HomePhone,
                Extension = saveEmployee.Extension,
                Photo = saveEmployee.Photo,
                Notes = saveEmployee.Notes,
                ReportsTo = saveEmployee.ReportsTo,
                PhotoPath = saveEmployee.PhotoPath
            };
            this.context.Employees.Add(employee);
            this.context.SaveChanges();
        }

        public void UpdateEmployee(EmployeesUpdateModels updateEmployee)
        {
            Employees employeeToUpdate = this.context.Employees.Find(updateEmployee.EmployeeId);

            if (employeeToUpdate == null)
            {
                throw new EmployeesException("Este empleado no se encuentra registrado.");
            }

            employeeToUpdate.LastName = updateEmployee.LastName;
            employeeToUpdate.FirstName = updateEmployee.FirstName;
            employeeToUpdate.Title = updateEmployee.Title;
            employeeToUpdate.TitleOfCourtesy = updateEmployee.TitleOfCourtesy;
            employeeToUpdate.BirthDate = updateEmployee.BirthDate;
            employeeToUpdate.HireDate = updateEmployee.HireDate;
            employeeToUpdate.Address = updateEmployee.Address;
            employeeToUpdate.City = updateEmployee.City;
            employeeToUpdate.Region = updateEmployee.Region;
            employeeToUpdate.PostalCode = updateEmployee.PostalCode;
            employeeToUpdate.Country = updateEmployee.Country;
            employeeToUpdate.HomePhone = updateEmployee.HomePhone;
            employeeToUpdate.Extension = updateEmployee.Extension;
            employeeToUpdate.Photo = updateEmployee.Photo;
            employeeToUpdate.Notes = updateEmployee.Notes;
            employeeToUpdate.ReportsTo = updateEmployee.ReportsTo;
            employeeToUpdate.PhotoPath = updateEmployee.PhotoPath;

            this.context.Employees.Update(employeeToUpdate);
            this.context.SaveChanges();
        }
    }
}