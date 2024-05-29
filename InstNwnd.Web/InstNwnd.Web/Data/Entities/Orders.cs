using InstNwnd.Web.Data.Core;

namespace InstNwnd.Web.Data.Entities
{
    public class Orders : BaseEntity
    {
        public int CustomerId { get; set; } 
        public int EmployeeId { get; set; } 
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int ShipVia { get; set; } 
        public decimal? Freight { get; set; } 

        // Información de envío
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }
}
