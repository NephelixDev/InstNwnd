using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.ShipperCrud;
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

        private Shippers ValidateShipperExists(int ShipperID)
        {
            var shippers = context.Shippers.Find(ShipperID);
            return shippers;
        }

        public List<ShippersGetModels> GetShippers()
        {
            return this.context.Shippers.Select(s => new ShippersGetModels
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone
            }).ToList();
        }

        public ShippersGetModels GetShippers(int shipperId)
        {
            var shipper = this.context.Shippers.Find(shipperId);

            if (shipper == null)
            {
                throw new Exception("This shipper is not registered.");
            }

            return new ShippersGetModels
            {
                ShipperID = shipper.ShipperID,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
        }

        public void RemoveShipper(ShippersRemoveModels removeShipper)
        {
            var shippers = context.Shippers.Find(removeShipper.ShipperID);

            this.context.Shippers.Remove(shippers);
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
            var shipperToUpdate = this.context.Shippers.Find(updateShipper.ShipperID);

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
