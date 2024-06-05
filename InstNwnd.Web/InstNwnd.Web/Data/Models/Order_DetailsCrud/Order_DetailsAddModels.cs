namespace InstNwnd.Web.Data.Models.Order_DetailsCrud
{
    public class Order_DetailsAddModels
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
    }
}
