 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstNwnd.Web.Data.Entities
{
    [Table("Suppliers", Schema = "dbo")]
    public class Suppliers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierID { get; set; }

        [Required]
        [MaxLength(40)]
        public string CompanyName { get; set; }

        [MaxLength(30)]
        public string? ContactName { get; set; } // Permite valores nulos

        [MaxLength(30)]
        public string? ContactTitle { get; set; } // Permite valores nulos

        [MaxLength(60)]
        public string? Address { get; set; } // Permite valores nulos

        [MaxLength(15)]
        public string? City { get; set; } // Permite valores nulos

        [MaxLength(15)]
        public string? Region { get; set; } // Permite valores nulos

        [MaxLength(10)]
        public string? PostalCode { get; set; } // Permite valores nulos

        [MaxLength(15)]
        public string? Country { get; set; } // Permite valores nulos

        [MaxLength(24)]
        public string? Phone { get; set; } // Permite valores nulos

        [MaxLength(24)]
        public string? Fax { get; set; } // Permite valores nulos

        [MaxLength(255)]
        public string? HomePage { get; set; } // Permite valores nulos

        // Eliminar o agregar otras columnas según la estructura real en la base de datos
    }
}
