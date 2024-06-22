namespace InstNwnd.Web.Data.Models.ProductCrud
{
    public class ProductUpdateModels
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; } // Debe ser string
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; } // Debe ser short
        public int? SupplierID { get; internal set; }
        public int? CategoryID { get; internal set; }
        public short? UnitsOnOrder { get; internal set; }
        public short? ReorderLevel { get; internal set; }
        public bool Discontinued { get; internal set; }

    }
}
