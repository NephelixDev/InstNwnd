

namespace InstNwnd.Web.Data.Interfaces
{
    public interface ICustomersDb
    {
        List<CustomersGetModels> GetCustomers();
        CustomersGetModels GetCustomers(string CustomerId);
        void SaveCustomer(CustomersSaveModels saveCustomer);
        void UpdateCustomer(CustomersUpdateModels updateCustomer);
        void RemoveCustomer(CustomersRemoveModels removeCustomer);
    }
}
