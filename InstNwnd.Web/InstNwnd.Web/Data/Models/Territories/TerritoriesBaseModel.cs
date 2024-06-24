using System.ComponentModel.DataAnnotations;

namespace InstNwnd.Web.Data.Models.Territories
{
    public abstract class TerritoryBaseModel : ModelBase
    {
        [Required]
        [StringLength(20)] 
        public string? TerritoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string? TerritoryDescription { get; set; }

        [Required]
        public int RegionID { get; set; }
    }
}
