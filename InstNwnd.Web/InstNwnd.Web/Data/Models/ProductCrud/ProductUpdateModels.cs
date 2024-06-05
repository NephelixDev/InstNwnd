namespace InstNwnd.Web.Data.Models.ProductCrud
{
    public class ProductUpdateModels
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string? Description { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool Deleted { get; set; }
    }
}
