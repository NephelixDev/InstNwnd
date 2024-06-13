using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Models.ShippersCrud;
using System.Collections.Generic;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface IShippersDb
    {
        List<Shippers> GetShippers();
        Shippers GetShipper(int shipperId);
        void SaveShipper(ShippersAddModels shipperAdd);
        void UpdateShipper(ShippersUpdateModels shipperUpdate);
        void RemoveShipper(ShippersRemoveModels shipperRemove);
    }
}
