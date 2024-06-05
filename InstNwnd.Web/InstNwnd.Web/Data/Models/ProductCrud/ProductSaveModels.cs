namespace InstNwnd.Web.Data.Models.ProductCrud
{
    public class ProductSaveModels
    {
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}
