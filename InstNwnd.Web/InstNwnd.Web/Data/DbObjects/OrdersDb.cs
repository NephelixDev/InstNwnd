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

        private Orders ValidateOrderExists(int orderId)
        {
            var order = this.context.Orders.Find(orderId);
            if (order == null)
            {
                throw new OrdersDbException("Este pedido no se encuentra registrado.");
            }
            return order;
        }

        private static OrdersModels MapToModel(Orders order)
        {
            return new OrdersModels
            {
                OrderId = order.OrderID,
                CustomerId = order.CustomerID,
                EmployeeID = order.EmployeeID,
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
        }

        private void MapToEntity(OrdersUpdateModels model, Orders entity)
        {
            entity.CustomerID = model.CustomerId;
            entity.EmployeeID = model.EmployeeID;
            entity.OrderDate = model.OrderDate;
            entity.RequiredDate = model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.ShipVia = model.ShipVia;
            entity.Freight = model.Freight;
            entity.ShipName = model.ShipName;
            entity.ShipAddress = model.ShipAddress;
            entity.ShipCity = model.ShipCity;
            entity.ShipRegion = model.ShipRegion;
            entity.ShipPostalCode = model.ShipPostalCode;
            entity.ShipCountry = model.ShipCountry;
            
        }

        private Orders MapToEntity(OrdersSaveModels model)
        {

            Orders entity = new Orders();
            entity.CustomerID = model.CustomerId;
            entity.EmployeeID = model.EmployeeID;
            entity.OrderDate = model.OrderDate;
            entity.RequiredDate = model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.ShipVia = model.ShipVia;
            entity.Freight = model.Freight;
            entity.ShipName = model.ShipName;
            entity.ShipAddress = model.ShipAddress;
            entity.ShipCity = model.ShipCity;
            entity.ShipRegion = model.ShipRegion;
            entity.ShipPostalCode = model.ShipPostalCode;
            entity.ShipCountry = model.ShipCountry;
                return entity;
            
        }

        public List<OrdersModels> GetOrders()
        {
            return this.context.Orders
                .Select(order => MapToModel(order))
                .ToList();
        }

        public OrdersModels GetOrder(int orderId)
        {
            var order = ValidateOrderExists(orderId);
            return MapToModel(order);
        }


        public void UpdateOrder(OrdersUpdateModels updateOrder)
        {
            var order = ValidateOrderExists(updateOrder.OrderId);
            MapToEntity(updateOrder, order);
            this.context.Orders.Update(order);
            this.context.SaveChanges();
        }

        public void RemoveOrder(OrdersRemoveModels removeOrder)
        {
            var order = ValidateOrderExists(removeOrder.OrderId);
            this.context.Orders.Remove(order);
            this.context.SaveChanges();
        }

        public void SaveOrder(OrdersSaveModels saveOrder)
        {
            var order = MapToEntity(saveOrder);
            this.context.Orders.Add(order);
            this.context.SaveChanges();
        }
    }
}
