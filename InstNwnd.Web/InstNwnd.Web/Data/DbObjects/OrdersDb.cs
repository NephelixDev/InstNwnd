using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.OrdersCrud;
using Microsoft.Extensions.Logging;  // Asegúrate de importar este namespace
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstNwnd.Web.Data.DbObjects
{
    public class OrdersDb : IOrdersDb
    {
        private readonly InstNwndContext context;
        private readonly ILogger<OrdersDb> logger;

        public OrdersDb(InstNwndContext context, ILogger<OrdersDb> logger)  // Agregamos el logger como parámetro
        {
            this.context = context;
            this.logger = logger;
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
            Orders entity = new Orders
            {
                CustomerID = model.CustomerId,
                EmployeeID = model.EmployeeID,
                OrderDate = model.OrderDate,
                RequiredDate = model.RequiredDate,
                ShippedDate = model.ShippedDate,
                ShipVia = model.ShipVia,
                Freight = model.Freight,
                ShipName = model.ShipName,
                ShipAddress = model.ShipAddress,
                ShipCity = model.ShipCity,
                ShipRegion = model.ShipRegion,
                ShipPostalCode = model.ShipPostalCode,
                ShipCountry = model.ShipCountry
            };
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
            try
            {
                var existingOrder = ValidateOrderExists(updateOrder.OrderId);
                MapToEntity(updateOrder, existingOrder);
                this.context.Orders.Update(existingOrder);
                int changes = this.context.SaveChanges();

                if (changes == 0)
                {
                    throw new OrdersDbException("No se realizaron cambios en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error al actualizar la orden.");
                throw;
            }
        }

        public void RemoveOrder(OrdersRemoveModels removeOrder)
        {
            try
            {
                var order = ValidateOrderExists(removeOrder.OrderId);
                this.context.Orders.Remove(order);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error al eliminar la orden.");
                throw;
            }
        }

        public void SaveOrder(OrdersSaveModels saveOrder)
        {
            try
            {
                var employeeExists = this.context.Employees.Any(e => e.EmployeeID == saveOrder.EmployeeID);
                if (!employeeExists)
                {
                    throw new OrdersDbException("El EmployeeID especificado no existe.");
                }

                var shipperExists = this.context.Shippers.Any(s => s.ShipperID == saveOrder.ShipVia);
                if (!shipperExists)
                {
                    throw new OrdersDbException("El ShipperID especificado no existe.");
                }

                var order = MapToEntity(saveOrder);

                if (string.IsNullOrEmpty(order.CustomerID))
                {
                    throw new OrdersDbException("El CustomerID es obligatorio.");
                }

                this.context.Orders.Add(order);
                int changes = this.context.SaveChanges();

                if (changes == 0)
                {
                    throw new OrdersDbException("No se realizaron cambios en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error al guardar el pedido.");
                throw;
            }
        }
    }
}
