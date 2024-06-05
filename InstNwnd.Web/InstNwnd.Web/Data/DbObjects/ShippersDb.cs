using InstNwnd.Web.BL.Exceptions;
using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.ShippersCrud;

namespace InstNwnd.Web.Data.DbObjects
{
    public class ShippersDb : IShippersDb
    {
        private readonly InstNwndContext context;

        public ShippersDb(InstNwndContext context)
        {
            this.context = context;
        }

        public ShippersModels GetShipper(int shipperId)
        {
            var shipper = this.context.Shippers.Find(shipperId);

            if (shipper == null)
            {
                throw new ShippersException("This shipper is not registered.");
            }

            return new ShippersModels()
            {
                ShipperId = shipper.ShipperID,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
        }

        public List<ShippersModels> GetShippers()
        {
            return this.context.Shippers.Select(s => new ShippersModels()
            {
                ShipperId = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone
            }).ToList();
        }

        public void RemoveShipper(ShippersRemoveModels removeShipper)
        {
            var shipperToDelete = this.context.Shippers.Find(removeShipper.ShipperId);

            if (shipperToDelete == null)
            {
                throw new ShippersException("This shipper is not registered.");
            }

            shipperToDelete.Deleted = removeShipper.Deleted;
 
            this.context.Shippers.Update(shipperToDelete);
            this.context.SaveChanges();
        }

        public void SaveShipper(ShippersAddModels saveShipper)
        {
            var shipper = new Shippers()
            {
                CompanyName = saveShipper.CompanyName,
                Phone = saveShipper.Phone
            };

            this.context.Shippers.Add(shipper);
            this.context.SaveChanges();
        }

        public void UpdateShipper(ShippersUpdateModels updateShipper)
        {
            var shipperToUpdate = this.context.Shippers.Find(updateShipper.ShipperId);

            if (shipperToUpdate == null)
            {
                throw new ShippersException("This shipper is not registered.");
            }

            shipperToUpdate.CompanyName = updateShipper.CompanyName;
            shipperToUpdate.Phone = updateShipper.Phone;

            this.context.Shippers.Update(shipperToUpdate);
            this.context.SaveChanges();
        }
    }
}
