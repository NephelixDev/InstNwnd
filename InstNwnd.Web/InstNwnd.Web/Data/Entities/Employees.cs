using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstNwnd.Web.Data.Entities
{
    [Table("Employees", Schema = "dbo")]
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [MaxLength(60)]
        public string? Title { get; set; }

        [MaxLength(60)]
        public string? Address { get; set; }

        [MaxLength(15)]
        public string? City { get; set; }

        [MaxLength(15)]
        public string? Region { get; set; }

        [MaxLength(10)]
        public string? PostalCode { get; set; }

        [MaxLength(15)]
        public string? Country { get; set; }

        [MaxLength(24)]
        public string? HomePhone { get; set; }
        [MaxLength(4)]
        public string? Extension { get; set; }
        public byte[]? Photo { get; set; }
        public string? Notes { get; set; }
        [ForeignKey("ReportsTo")]
        public int? ReportsTo { get; set; }
        [MaxLength(255)]
        public string? PhotoPath { get; set; }
      
        // Propiedad de navegación
        public ICollection<Orders> Orders { get; set; }
    }
}