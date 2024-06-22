using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.SupplierCrud;
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

        private Suppliers ValidateSupplierExists(int supplierID)
        {
            var supplier = context.Suppliers.Find(supplierID);
            return supplier;
        }

        public List<SupplierGetModels> GetSuppliers()
        {
            return this.context.Suppliers.Select(s => new SupplierGetModels
            {
                SupplierID = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                ContactTitle = s.ContactTitle,
                Address = s.Address,
                City = s.City,
                Region = s.Region,
                PostalCode = s.PostalCode,
                Country = s.Country,
                Phone = s.Phone,
                Fax = s.Fax,
                HomePage = s.HomePage
            }).ToList();
        }

        public SupplierGetModels GetSupplier(int supplierId)
        {
            var supplier = this.context.Suppliers.Find(supplierId);

            if (supplier == null)
            {
                throw new Exception("This supplier is not registered.");
            }

            return new SupplierGetModels
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                HomePage = supplier.HomePage
            };
        }

        public void RemoveSupplier(int supplierId)
        {
            var supplierToDelete = this.context.Suppliers.Find(supplierId);

            if (supplierToDelete == null)
            {
                throw new Exception("This supplier is not registered.");
            }

            this.context.Suppliers.Remove(supplierToDelete);
            this.context.SaveChanges();
        }

        public void RemoveSupplier(SuppliersRemoveModels removeSupplier)
        {
            var supplierToDelete = this.context.Suppliers.Find(removeSupplier.SupplierID);

            if (supplierToDelete == null)
            {
                throw new Exception("This supplier is not registered.");
            }

            this.context.Suppliers.Remove(supplierToDelete);
            this.context.SaveChanges();
        }

        public void SaveSupplier(SuppliersAddModels saveSupplier)
        {
            var supplier = new Suppliers
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
            var supplierToUpdate = this.context.Suppliers.Find(updateSupplier.SupplierID);

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

        public SupplierGetModels GetSuppliers(int supplierId)
        {
            var supplier = this.context.Suppliers.Find(supplierId);

            if (supplier == null)
            {
                throw new Exception("This supplier is not registered.");
            }

            return new SupplierGetModels
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                HomePage = supplier.HomePage
            };
        }
    }
}
