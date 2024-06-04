namespace InstNwnd.Web.Data.Entities
{
    public class Territories
    {
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }
        public object Id { get; internal set; }
        public object TerritoryName { get; internal set; }
        public object Deleted { get; internal set; }
    }
}
