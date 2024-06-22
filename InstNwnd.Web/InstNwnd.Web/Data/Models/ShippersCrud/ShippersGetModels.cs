namespace InstNwnd.Web.Data.Models.ShipperCrud
{
    public class ShippersGetModels
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
