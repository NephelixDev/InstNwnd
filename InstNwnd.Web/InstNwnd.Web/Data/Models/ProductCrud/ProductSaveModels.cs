namespace InstNwnd.Web.Data.Models.ProductCrud
{
    public class ProductSaveModels
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public bool Discontinued { get; set; }
        public bool DeleteDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public int ChangeUser { get; set; }
    }
}
