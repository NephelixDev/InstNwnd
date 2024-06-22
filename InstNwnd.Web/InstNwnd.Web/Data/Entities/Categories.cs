using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InstNwnd.Web.Data.Core;

namespace InstNwnd.Web.Data.Entities
{
    [Table("Categories", Schema = "dbo")]
    public class Categories 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public byte[]? Picture { get; set; }
        
    }
}
