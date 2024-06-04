namespace InstNwnd.Web.Data.Models.RegionCrud
{
    public class RegionRemoveModels
    {
        public int RegionId { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeleteDate { get; set; }
        public string? RegionDescription { get; set; }
        public object RegionName { get; internal set; }
        public object Description { get; internal set; }
    }
}
