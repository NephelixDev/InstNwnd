using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.Order_DetailsCrud;
using System.Collections.Generic;
using System.Linq;

namespace InstNwnd.Web.Data.DbObjects
{
    public class Order_DetailsDb : IOrders_DetailsDb
    {
        private readonly InstNwndContext _context;

        public Order_DetailsDb(InstNwndContext context)
        {
            _context = context;
        }

        public Order_DetailsModels GetOrderDetail(int orderId, int productId)
        {
            var orderDetail = _context.Order_Details.Find(orderId, productId);

            if (orderDetail == null)
            {
                throw new Order_DetailsDbException("Este detalle de pedido no se encuentra registrado.");
            }

            Order_DetailsModels orderDetailModel = new Order_DetailsModels()
            {
                OrderID = orderDetail.OrderID,
                ProductID = orderDetail.ProductID,
                UnitPrice = orderDetail.UnitPrice,
                Quantity = orderDetail.Quantity,
                Discount = orderDetail.Discount
            };

            return orderDetailModel;
        }

        public List<Order_DetailsModels> GetOrderDetails()
        {
            return _context.Order_Details.Select(od => new Order_DetailsModels()
            {
                OrderID = od.OrderID,
                ProductID = od.ProductID,
                UnitPrice = od.UnitPrice,
                Quantity = od.Quantity,
                Discount = od.Discount
            }).ToList();
        }

        public void RemoveOrderDetail(Order_DetailsRemoveModels removeOrderDetail)
        {
            var orderDetailToDelete = _context.Order_Details.Find(removeOrderDetail.OrderID, removeOrderDetail.ProductID);

            if (orderDetailToDelete == null)
            {
                throw new Order_DetailsDbException("Este detalle de pedido no se encuentra registrado.");
            }

            _context.Order_Details.Remove(orderDetailToDelete);
            _context.SaveChanges();
        }

        public void SaveOrderDetail(Order_DetailsSaveModels saveOrderDetail)
        {
            var orderDetail = new Order_Details()
            {
                OrderID = saveOrderDetail.OrderID,
                ProductID = saveOrderDetail.ProductID,
                UnitPrice = saveOrderDetail.UnitPrice,
                Quantity = saveOrderDetail.Quantity,
                Discount = saveOrderDetail.Discount
            };
            _context.Order_Details.Add(orderDetail);
            _context.SaveChanges();
        }

        public void UpdateOrderDetail(Order_DetailsUpdateModels updateOrderDetail)
        {
            var orderDetailToUpdate = _context.Order_Details.Find(updateOrderDetail.OrderID, updateOrderDetail.ProductID);

            if (orderDetailToUpdate == null)
            {
                throw new Order_DetailsDbException("Este detalle de pedido no se encuentra registrado.");
            }

            orderDetailToUpdate.UnitPrice = updateOrderDetail.UnitPrice;
            orderDetailToUpdate.Quantity = updateOrderDetail.Quantity;
            orderDetailToUpdate.Discount = updateOrderDetail.Discount;

            _context.SaveChanges();
        }
    }
}
