using InstNwnd.Web.BL.Exceptions;
using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.OrdersCrud;
using System.Collections.Generic;
using System.Linq;

namespace InstNwnd.Web.Data.DbObjects
{
    public class OrdersDb : IOrdersDb
    {
        private readonly InstNwndContext context;

        public OrdersDb(InstNwndContext context)
        {
            this.context = context;
        }

        public OrdersModels GetOrder(int orderId)
        {
            var order = this.context.Orders.Find(orderId);

            if (order == null)
            {
                throw new OrdersException("Esta orden no se encuentra registrada.");
            }

            OrdersModels orderModel = new OrdersModels()
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry
            };

            return orderModel;
        }

        public List<OrdersModels> GetOrders()
        {
            return this.context.Orders.Select(o => new OrdersModels()
            {
                OrderId = o.OrderId,
                CustomerId = o.CustomerId,
                EmployeeId = o.EmployeeId,
                OrderDate = o.OrderDate,
                RequiredDate = o.RequiredDate,
                ShippedDate = o.ShippedDate,
                ShipVia = o.ShipVia,
                Freight = o.Freight,
                ShipName = o.ShipName,
                ShipAddress = o.ShipAddress,
                ShipCity = o.ShipCity,
                ShipRegion = o.ShipRegion,
                ShipPostalCode = o.ShipPostalCode,
                ShipCountry = o.ShipCountry
            }).ToList();
        }

        public void RemoveOrder(OrdersRemoveModels removeOrder)
        {
            Orders orderToDelete = this.context.Orders.Find(removeOrder.OrderId);

            if (orderToDelete == null)
            {
                throw new OrdersDbException("Esta orden no se encuentra registrada.");
            }

            this.context.Orders.Remove(orderToDelete);
            this.context.SaveChanges();
        }

        public void SaveOrder(OrdersSaveModels saveOrder)
        {
            Orders order = new Orders()
            {
                CustomerId = saveOrder.CustomerId,
                EmployeeId = saveOrder.EmployeeId,
                OrderDate = saveOrder.OrderDate,
                RequiredDate = saveOrder.RequiredDate,
                ShippedDate = saveOrder.ShippedDate,
                ShipVia = saveOrder.ShipVia,
                Freight = saveOrder.Freight,
                ShipName = saveOrder.ShipName,
                ShipAddress = saveOrder.ShipAddress,
                ShipCity = saveOrder.ShipCity,
                ShipRegion = saveOrder.ShipRegion,
                ShipPostalCode = saveOrder.ShipPostalCode,
                ShipCountry = saveOrder.ShipCountry
            };
            this.context.Orders.Add(order);
            this.context.SaveChanges();
        }


        public void UpdateOrder(OrdersUpdateModels updateOrder)
        {
            Orders orderToUpdate = this.context.Orders.Find(updateOrder.OrderId);

            if (orderToUpdate == null)
            {
                throw new OrdersException("Esta orden no se encuentra registrada.");
            }

            orderToUpdate.CustomerId = updateOrder.CustomerId;
            orderToUpdate.EmployeeId = updateOrder.EmployeeId;
            orderToUpdate.OrderDate = updateOrder.OrderDate;
            orderToUpdate.RequiredDate = updateOrder.RequiredDate;
            orderToUpdate.ShippedDate = updateOrder.ShippedDate;
            orderToUpdate.ShipVia = updateOrder.ShipVia;
            orderToUpdate.Freight = updateOrder.Freight;
            orderToUpdate.ShipName = updateOrder.ShipName;
            orderToUpdate.ShipAddress = updateOrder.ShipAddress;
            orderToUpdate.ShipCity = updateOrder.ShipCity;
            orderToUpdate.ShipRegion = updateOrder.ShipRegion;
            orderToUpdate.ShipPostalCode = updateOrder.ShipPostalCode;
            orderToUpdate.ShipCountry = updateOrder.ShipCountry;

            this.context.Orders.Update(orderToUpdate);
            this.context.SaveChanges();
        }
    }
}
