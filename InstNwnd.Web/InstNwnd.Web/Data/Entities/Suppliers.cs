using InstNwnd.Web.Data.Core;

namespace InstNwnd.Web.Data.Entities
{
    public class Suppliers : BaseEntity
    {

        public string CompanyName { get; set; }  
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
            public string Homepage { get; set; }
    }
}
