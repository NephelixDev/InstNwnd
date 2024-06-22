using InstNwnd.Web.Data.Models.Order_DetailsCrud;

namespace InstNwnd.Web.Data.Models.OrdersCrud.Orders
{
    public class OrdersRemoveModels : BaseOrdersModels
    {
        public bool Deleted { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}