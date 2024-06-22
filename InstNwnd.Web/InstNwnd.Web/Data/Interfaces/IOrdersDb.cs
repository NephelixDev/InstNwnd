using InstNwnd.Web.Data.Models.OrderCrud;
using InstNwnd.Web.Data.Models.OrdersCrud;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface IOrdersDb
    {
        List<OrdersModels> GetOrders();
        OrdersModels GetOrder(int orderId);
        void SaveOrder(OrdersSaveModels saveOrder);
        void UpdateOrder(OrdersUpdateModels updateOrder);
        void RemoveOrder(OrdersRemoveModels removeOrder);
    }
}
