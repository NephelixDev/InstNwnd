using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstNwnd.Web.Data.Entities
{
    [Table("Products", Schema = "dbo")]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(40)]
            public string ProductName { get; set; }
            public int? SupplierID { get; set; }
            public int? CategoryID { get; set; }
            public string QuantityPerUnit { get; set; } // Debe ser string
            public decimal? UnitPrice { get; set; }
            public short? UnitsInStock { get; set; } // Debe ser short
            public bool Discontinued { get; set; }
        public short? ReorderLevel { get; internal set; }
        public short? UnitsOnOrder { get; internal set; }
    }
    }


 


