namespace InstNwnd.Web.Data.Models.Territories
{
    public abstract class TerritoryBaseModel : ModelBase
    {
        public string? TerritoryID { get; set; }
        public string? TerritoryDescription { get; set; }
        public int RegionID { get; set; }
    }



}
