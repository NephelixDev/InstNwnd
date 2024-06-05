using InstNwnd.Web.BL.Exceptions;
using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.CustomersCrud;

namespace InstNwnd.Web.Data.DbObjects
{
    public class CustomersDb : ICustomersDb
    {
        private readonly InstNwndContext context;

        public CustomersDb(InstNwndContext context)
        {
            this.context = context;
        }

        public CustomersModels GetCustomer(string customerId)
        {
            var customer = this.context.Customers.Find(customerId);

            if (customer == null)
            {
                throw new CustomersDbException("Este cliente no se encuentra registrado.");
            }

            CustomersModels customerModel = new CustomersModels()
            {
                CustomerId = customer.Id,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle
            };

            return customerModel;
        }

        public List<CustomersModels> GetCustomers()
        {
            return this.context.Customers.Select(c => new CustomersModels()
            {
                CustomerId = c.Id,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                ContactTitle = c.ContactTitle
            }).ToList();
        }

        public void RemoveCustomer(Order_DetailsRemoveModels removeCustomer)
        {
            Customers customerToDelete = this.context.Customers.Find(removeCustomer.CustomerId);

            if (customerToDelete == null)
            {
                throw new CustomersDbException("Este cliente no se encuentra registrado.");
            }

            this.context.Customers.Remove(customerToDelete);
            this.context.SaveChanges();
        }

        public void SaveCustomer(Order_DetailsAddModels saveCustomer)
        {
            Customers customer = new Customers()
            {
                CompanyName = saveCustomer.CompanyName,
                ContactName = saveCustomer.ContactName,
                ContactTitle = saveCustomer.ContactTitle
            };
            this.context.Customers.Add(customer);
            this.context.SaveChanges();
        }

        public void UpdateCustomer(CustomersUpdateModels updateCustomer)
        {
            Customers customerToUpdate = this.context.Customers.Find(updateCustomer.CustomerId);

            if (customerToUpdate == null)
            {
                throw new CustomerException("Este cliente no se encuentra registrado.");
            }

            customerToUpdate.CompanyName = updateCustomer.CompanyName;
            customerToUpdate.ContactName = updateCustomer.ContactName;
            customerToUpdate.ContactTitle = updateCustomer.ContactTitle;

            this.context.SaveChanges();
        }

    }
}
