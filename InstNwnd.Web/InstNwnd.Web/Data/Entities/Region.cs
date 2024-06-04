using InstNwnd.Web.Data.Core;

namespace InstNwnd.Web.Data.Entities
{
    public class Region :BaseEntity
    {
     public string RegionDescription { get; set; }
        public object RegionName { get; internal set; }
        public object Description { get; internal set; }
        public object Deleted { get; internal set; }
        public int RegionID { get; internal set; }
        public DateTime ModifyDate { get; internal set; }
    }
}
