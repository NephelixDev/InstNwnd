using InstNwnd.Web.Data.Models.Order_DetailsCrud;
using System.Collections.Generic;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface IOrder_DetailsDb
    {
        List<Order_DetailsGetModels> GetOrder_Details();
        Order_DetailsGetModels GetOrder_Details(int orderId, int productId);
        void SaveOrderDetail(Order_DetailsSaveModels saveOrderDetail);
        void UpdateOrderDetail(Order_DetailsUpdateModels updateOrderDetail);
        void RemoveOrderDetails(Order_DetailsRemoveModels removeOrderDetail);
    }
}
