using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.EmployeeCrud;
using InstNwnd.Web.Data.Models.EmployeesCrud;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace InstNwnd.Web.Data.DbObjects
{
    public class EmployeesDb : IEmployeesDb
    {
        private readonly InstNwndContext context;
        

        public EmployeesDb(InstNwndContext context, ILogger<EmployeesDb> logger)
        {
            this.context = context;
            
        }

        private Employees ValidateEmployeeExists(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);
            if (employee == null)
            {
                
                throw new EmployeesDbException("Este empleado no se encuentra registrado.");
            }
            return employee;
        }

        private static EmployeesModels MapToModel(Employees employees) => new EmployeesModels
        {
            EmployeeID = employees.EmployeeID,
            FirstName = employees.FirstName,
            LastName = employees.LastName,
            Title = employees.Title,
            Address = employees.Address,
            City = employees.City,
            Region = employees.Region,
            PostalCode = employees.PostalCode,
            Country = employees.Country,
            HomePhone = employees.HomePhone,
            Extension = employees.Extension,
            Photo = employees.Photo,
            Notes = employees.Notes,
            ReportsTo = employees.ReportsTo,
            PhotoPath = employees.PhotoPath
        };
        private void MapToEntity(EmployeesUpdateModels model, Employees entity)
        {
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Title = model.Title;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.HomePhone = model.HomePhone;
            entity.Extension = model.Extension;
            entity.Photo = model.Photo;
            entity.Notes = model.Notes;
            entity.ReportsTo = model.ReportsTo;
            entity.PhotoPath = model.PhotoPath;
        }

        private Employees MapToEntity(EmployeesSaveModels model)
        {

            Employees entity = new Employees();
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Title = model.Title;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.HomePhone = model.HomePhone;
            entity.Extension = model.Extension;
            entity.Photo = model.Photo;
            entity.Notes = model.Notes;
            entity.ReportsTo = model.ReportsTo;
            entity.PhotoPath = model.PhotoPath;
                return entity;
        }
        private static EmployeeGetModels MapToGetModel(EmployeesModels model)
        {
            return new EmployeeGetModels
            {
                EmployeeID = model.EmployeeID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title,
                Address = model.Address,
                City = model.City,
                Region = model.Region,
                PostalCode = model.PostalCode,
                Country = model.Country,
                HomePhone = model.HomePhone,
                Extension = model.Extension,
                Photo = model.Photo,
                Notes = model.Notes,
                ReportsTo = model.ReportsTo,
                PhotoPath = model.PhotoPath
            };
        }

        public List<EmployeesModels> GetEmployees()
        {
            return this.context.Employees
                .Select(employee => MapToModel(employee))
                .ToList();
        }

        public EmployeesModels GetEmployee(int employeeId)
        {
            var employee = ValidateEmployeeExists(employeeId);
            return MapToModel(employee);
        }
        public void UpdateEmployee(EmployeesUpdateModels updateEmployee)
        {
            
           var employees = ValidateEmployeeExists(updateEmployee.EmployeeID);
            MapToEntity(updateEmployee, employees);
            this.context.Employees.Update(employees);
            this.context.SaveChanges();
            
        }
        public void SaveEmployee(EmployeesSaveModels saveEmployee)
        {
            
            var employee = MapToEntity(saveEmployee);
            this.context.Employees.Add(employee);
            this.context.SaveChanges();
            
        }
        public void RemoveEmployee(EmployeesRemoveModels removeEmployee)
        {
            var employee = ValidateEmployeeExists(removeEmployee.EmployeeID);
            this.context.Employees.Remove(employee);
            this.context.SaveChanges();
            
        }
    }
}
