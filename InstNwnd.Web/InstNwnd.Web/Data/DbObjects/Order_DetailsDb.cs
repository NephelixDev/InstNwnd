using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.Order_DetailsCrud;


namespace InstNwnd.Web.Data.DbObjects
{
    public class Order_DetailsDb : IOrder_DetailsDb
    {
        private readonly InstNwndContext context;

        public Order_DetailsDb(InstNwndContext context)
        {
            this.context = context;
        }

        private Order_Details ValidateOrderDetailExists(int orderId, int productId)
        {
            var orderDetail = this.context.Order_Details.Find(orderId, productId);

            if (orderDetail == null)
            {
                throw new Order_DetailsDbException("Este detalle de pedido no se encuentra registrado.");
            }

            return orderDetail;
        }


        private static Order_DetailsGetModels MapToModel(Order_Details orderDetail)
        {
            return new Order_DetailsGetModels
            {
                OrderID = orderDetail.OrderID,
                ProductID = orderDetail.ProductID,
                UnitPrice = orderDetail.UnitPrice,
                Quantity = orderDetail.Quantity,
                Discount = orderDetail.Discount
            };
        }

        private Order_Details MapToEntity(Order_DetailsSaveModels model)
        {
            var entity = new Order_Details();
            entity.OrderID = model.OrderID;
            entity.ProductID = model.ProductID;
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;
            return entity;
        }

        private void MapToEntity(Order_DetailsUpdateModels model, Order_Details entity)
        {
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;
        }

        public List<Order_DetailsGetModels> GetOrder_Details()
        {
            return this.context.Order_Details
                .Select(orderDetail => MapToModel(orderDetail))
                .ToList();
        }

        public Order_DetailsGetModels GetOrder_Details(int orderId, int productId)
        {
            var orderDetail = ValidateOrderDetailExists(orderId, productId);
            return MapToModel(orderDetail);
        }

        public void RemoveOrderDetails(Order_DetailsRemoveModels removeOrderDetail)
        {
            var orderDetail = ValidateOrderDetailExists(removeOrderDetail.OrderID, removeOrderDetail.ProductID);
            this.context.Order_Details.Remove(orderDetail);
            this.context.SaveChanges();
        }

        public void SaveOrderDetail(Order_DetailsSaveModels saveOrderDetail)
        {
            var orderDetail = MapToEntity(saveOrderDetail);
            this.context.Order_Details.Add(orderDetail);
            this.context.SaveChanges();
        }

        public void UpdateOrderDetail(Order_DetailsUpdateModels updateOrderDetail)
        {
            var orderDetail = ValidateOrderDetailExists(updateOrderDetail.OrderID, updateOrderDetail.ProductID);
            MapToEntity(updateOrderDetail, orderDetail);
            this.context.SaveChanges();
        }
    }
}
