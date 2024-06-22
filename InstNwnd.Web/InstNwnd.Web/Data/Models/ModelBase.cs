namespace InstNwnd.Web.Data.Models
{
    public class ModelBase
    {
        public abstract class TerritoryBaseModel : ModelBase
        {
            public string? TerritoryID { get; set; }
            public string? TerritoryDescription { get; set; }
            public int RegionID { get; set; }
        }

        public abstract class RegionBaseModel : ModelBase
        {
            public int RegionID { get; set; }
            public string? RegionDescription { get; set; }
        }
    }
}
