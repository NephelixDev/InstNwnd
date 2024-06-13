using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.SuppliersCrud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstNwnd.Web.Data.DbObjects
{
    public class SuppliersDb : ISuppliersDb
    {
        private readonly InstNwndContext context;

        public SuppliersDb(InstNwndContext context)
        {
            this.context = context;
        }

        public Suppliers GetSupplier(int supplierId)
        {
            var supplier = this.context.Suppliers.Find(supplierId);

            if (supplier == null)
            {
                throw new Exception("This supplier is not registered.");
            }

            return supplier;
        }

        public List<Suppliers> GetSuppliers()
        {
            return this.context.Suppliers.ToList();
        }

        public void RemoveSupplier(SuppliersRemoveModels removeSupplier)
        {
            var supplierToDelete = this.context.Suppliers.Find(removeSupplier.SupplierId);

            if (supplierToDelete == null)
            {
                throw new Exception("This supplier is not registered.");
            }

            this.context.Suppliers.Remove(supplierToDelete);
            this.context.SaveChanges();
        }

        public void SaveSupplier(SuppliersAddModels saveSupplier)
        {
            var supplier = new Suppliers()
            {
                CompanyName = saveSupplier.CompanyName,
                ContactName = saveSupplier.ContactName,
                ContactTitle = saveSupplier.ContactTitle,
                Address = saveSupplier.Address,
                City = saveSupplier.City,
                Region = saveSupplier.Region,
                PostalCode = saveSupplier.PostalCode,
                Country = saveSupplier.Country,
                Phone = saveSupplier.Phone,
                Fax = saveSupplier.Fax,
                HomePage = saveSupplier.HomePage
            };

            this.context.Suppliers.Add(supplier);
            this.context.SaveChanges();
        }

        public void UpdateSupplier(SuppliersUpdateModels updateSupplier)
        {
            var supplierToUpdate = this.context.Suppliers.Find(updateSupplier.SupplierId);

            if (supplierToUpdate == null)
            {
                throw new Exception("This supplier is not registered.");
            }

            supplierToUpdate.CompanyName = updateSupplier.CompanyName;
            supplierToUpdate.ContactName = updateSupplier.ContactName;
            supplierToUpdate.ContactTitle = updateSupplier.ContactTitle;
            supplierToUpdate.Address = updateSupplier.Address;
            supplierToUpdate.City = updateSupplier.City;
            supplierToUpdate.Region = updateSupplier.Region;
            supplierToUpdate.PostalCode = updateSupplier.PostalCode;
            supplierToUpdate.Country = updateSupplier.Country;
            supplierToUpdate.Phone = updateSupplier.Phone;
            supplierToUpdate.Fax = updateSupplier.Fax;
            supplierToUpdate.HomePage = updateSupplier.HomePage;

            this.context.Suppliers.Update(supplierToUpdate);
            this.context.SaveChanges();
        }
    }
}
