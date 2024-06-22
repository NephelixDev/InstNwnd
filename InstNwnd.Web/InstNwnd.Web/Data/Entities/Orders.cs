using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstNwnd.Web.Data.Entities
{
    [Table("Orders", Schema = "dbo")]
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [ForeignKey("CustomerID")]
        public string? CustomerID { get; set; }

        [Required]
        public int? EmployeeID { get; set; }

        [Required]
        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }
        [ForeignKey("ShipVia")]
        public int? ShipVia { get; set; }

        public decimal? Freight { get; set; }
        [MaxLength(40)]
        public string? ShipName { get; set; }

        [MaxLength(60)]
        public string? ShipAddress { get; set; }

        [MaxLength(15)]
        public string? ShipCity { get; set; }

        [MaxLength(15)]
        public string? ShipRegion { get; set; }

        [MaxLength(10)]
        public string? ShipPostalCode { get; set; }

        [MaxLength(15)]
        public string? ShipCountry { get; set; }

        // Propiedad de navegación
        [ForeignKey("EmployeeID")]
        public Employees Employee { get; set; }
    }
}