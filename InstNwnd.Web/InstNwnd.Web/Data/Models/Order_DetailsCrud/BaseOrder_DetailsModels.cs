namespace InstNwnd.Web.Data.Models.Order_DetailsCrud
{
        public class BaseOrder_DetailsModels
    {
            public int OrderID { get; set; }
            public int ProductID { get; set; }
            public decimal UnitPrice { get; set; }
            public short Quantity { get; set; }
            public float Discount { get; set; }
        }
}