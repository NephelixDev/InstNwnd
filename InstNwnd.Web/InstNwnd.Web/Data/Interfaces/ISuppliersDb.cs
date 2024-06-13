using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Models.SuppliersCrud;
using System.Collections.Generic;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface ISuppliersDb
    {
        List<Suppliers> GetSuppliers();
        Suppliers GetSupplier(int supplierId);
        void SaveSupplier(SuppliersAddModels supplierAdd);
        void UpdateSupplier(SuppliersUpdateModels supplierUpdate);
        void RemoveSupplier(SuppliersRemoveModels supplierRemove);
    }
}
