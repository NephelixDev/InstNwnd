using System.ComponentModel.DataAnnotations;

namespace InstNwnd.Web.Data.Models.Region
{
    public class RegionBaseModel : ModelBase
    {
        [Required]
        public int RegionID { get; set; }

        [Required]
        [StringLength(50)]
        public string? RegionDescription { get; set; }
    }
}
