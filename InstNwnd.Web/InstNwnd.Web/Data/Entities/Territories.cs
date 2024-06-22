using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InstNwnd.Web.Data.Core;

namespace InstNwnd.Web.Data.Entities
{
    [Table("Territories", Schema = "dbo")]
    public class Territories 
    {
        [Key]
        [MaxLength(20)] // Según el diseño de la base de datos de Northwind, TerritoryID es una cadena
        public string TerritoryID { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string TerritoryDescription { get; set; } = string.Empty;

        [ForeignKey("Region")]
        public int RegionID { get; set; }

        // Las propiedades heredadas de BaseEntity ya están definidas en BaseEntity
    }
}
