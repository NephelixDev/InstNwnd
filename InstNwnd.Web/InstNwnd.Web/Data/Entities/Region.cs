using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InstNwnd.Web.Data.Core;
using System.Collections.Generic;
using System.Linq;

namespace InstNwnd.Web.Data.Entities
{
    [Table("Region", Schema = "dbo")]
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegionID { get; set; }

        [Required]
        [MaxLength(50)]
        public string RegionDescription { get; set; } = string.Empty;

        // Las propiedades heredadas de BaseEntity ya están definidas en BaseEntity
    }
}
