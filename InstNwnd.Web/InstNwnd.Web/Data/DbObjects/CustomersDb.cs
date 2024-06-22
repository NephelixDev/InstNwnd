using InstNwnd.Web.Data.Models.CustomersCrud;
using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;



namespace InstNwnd.Web.Data.DbObjects

{
    public class CustomersDb : ICustomersDb
    {
        private readonly InstNwndContext context;

        public CustomersDb(InstNwndContext context)
        {
            this.context = context;
        }

        private Customers ValidateCustomerExists(string customerId)
        {
            var customer = this.context.Customers.Find(customerId);

            if (customer == null)
            {
                throw new CustomersDbException("Este cliente no se encuentra registrado.");
            }

            return customer;
        }

        private static CustomersGetModels MapToModel(Customers entity)
        {
            return new CustomersGetModels
            {
                CustomerId = entity.CustomerId,
                CompanyName = entity.CompanyName,
                ContactName = entity.ContactName,
                ContactTitle = entity.ContactTitle,
                Address = entity.Address,
                City = entity.City,
                Region = entity.Region,
                PostalCode = entity.PostalCode,
                Country = entity.Country,
                Phone = entity.Phone,
                Fax = entity.Fax
            };
        }

        private void MapToEntity(CustomersUpdateModels model, Customers entity)
        {
            entity.CustomerId = model.CustomerId;
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.Phone = model.Phone;
            entity.Fax = model.Fax;
        }

        private Customers MapToEntity(CustomersSaveModels model)
        {

            Customers entity = new Customers();
            entity.CustomerId = model.CustomerId;
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.Phone = model.Phone;
            entity.Fax = model.Fax;
            return entity;


        }

        public List<CustomersGetModels> GetCustomers()
        {
         return context.Customers.Select(customer => MapToModel(customer)).ToList();
                
                
        }

        public CustomersGetModels GetCustomers(string customerId)
        {
            var customer = ValidateCustomerExists(customerId);
            return MapToModel(customer);
        }

        public void RemoveCustomer(CustomersRemoveModels removeCustomer)
        {
            var customer = ValidateCustomerExists(removeCustomer.CustomerId);
            this.context.Customers.Remove(customer);
            this.context.SaveChanges();
        }

        public void SaveCustomer(CustomersSaveModels saveCustomer)
        {
            var customer = MapToEntity(saveCustomer);
            this.context.Customers.Add(customer);
            this.context.SaveChanges();
        }

        public void UpdateCustomer(CustomersUpdateModels updateCustomer)
        {
            var customer=ValidateCustomerExists(updateCustomer.CustomerId); 
            MapToEntity(updateCustomer, customer);
            context.Customers.Update(customer);
            context.SaveChanges();
        }
    }
}
