using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.ShippersCrud;
 using System;
using System.Collections.Generic;
using System.Linq;

namespace InstNwnd.Web.Data.DbObjects
{
    public class ShippersDb : IShippersDb
    {
        private readonly InstNwndContext context;

        public ShippersDb(InstNwndContext context)
        {
            this.context = context;
        }

        public Shippers GetShipper(int shipperId)
        {
            var shipper = this.context.Shippers.Find(shipperId);

            if (shipper == null)
            {
                throw new Exception("This shipper is not registered.");
            }

            return shipper;
        }

        public List<Shippers> GetShippers()
        {
            return this.context.Shippers.ToList();
        }

        public void RemoveShipper(ShippersRemoveModels removeShipper)
        {
            var shipperToDelete = this.context.Shippers.Find(removeShipper.ShipperId);

            if (shipperToDelete == null)
            {
                throw new Exception("This shipper is not registered.");
            }

            this.context.Shippers.Remove(shipperToDelete);
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
                throw new Exception("This shipper is not registered.");
            }

            shipperToUpdate.CompanyName = updateShipper.CompanyName;
            shipperToUpdate.Phone = updateShipper.Phone;

            this.context.Shippers.Update(shipperToUpdate);
            this.context.SaveChanges();
        }
    }
}
