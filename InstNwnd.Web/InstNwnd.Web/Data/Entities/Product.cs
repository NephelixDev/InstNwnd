using InstNwnd.Web.Data.Core;
using System;

public class Product : BaseEntity
{
    public string ProductName { get; set; }

    public int? SupplierID { get; set; }
    public int? CategoryID { get; set; }

    public string QuantityPerUnit { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
    public short? UnitsOnOrder { get; set; }
    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public string Description { get; set; }   
    public DateTime? DeleteDate { get; set; }  
 }
