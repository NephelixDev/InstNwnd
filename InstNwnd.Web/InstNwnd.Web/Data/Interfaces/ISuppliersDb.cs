using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Models.SupplierCrud;
using InstNwnd.Web.Data.Models.SuppliersCrud;
using System.Collections.Generic;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface ISuppliersDb
    {
        List<SupplierGetModels> GetSuppliers();
        SupplierGetModels GetSuppliers(int supplierId); // Actualizar el tipo de retorno aquí
        void SaveSupplier(SuppliersAddModels saveSupplier);
        void UpdateSupplier(SuppliersUpdateModels updateSupplier);
        void RemoveSupplier(SuppliersRemoveModels RemoveSupplier);
    }
}
