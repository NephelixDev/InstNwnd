using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstNwnd.Web.Data.Entities
{
    public class Order_Details
    {
        public int OrderID { get; set; }

        [Key]
        public int ProductID { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        // Propiedades de navegación básicas
        public virtual object Order { get; set; }
        public virtual object Product { get; set; }
    }
}
