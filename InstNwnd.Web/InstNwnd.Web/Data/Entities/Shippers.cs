using InstNwnd.Web.Data.Core;

namespace InstNwnd.Web.Data.Entities
{
    public class Shippers : BaseEntity
    {
        public int ShipperID { get; set; }  

        public string CompanyName { get; set; }
        public new string Phone { get; set; }
    }
}
