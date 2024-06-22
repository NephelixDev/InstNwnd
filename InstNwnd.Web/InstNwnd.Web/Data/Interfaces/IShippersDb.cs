using InstNwnd.Web.Data.Models.ShipperCrud;
using InstNwnd.Web.Data.Models.ShippersCrud;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface IShippersDb
    {
        ShippersGetModels GetShippers(int shipperId);
        List<ShippersGetModels> GetShippers();
        void RemoveShipper(ShippersRemoveModels removeShipper);
        void SaveShipper(ShippersAddModels saveShipper);
        void UpdateShipper(ShippersUpdateModels updateShipper);
    }
}
