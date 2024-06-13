namespace InstNwnd.Web.Data.Models.ShipperCrud
{
    public class ShipperGetModels
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
