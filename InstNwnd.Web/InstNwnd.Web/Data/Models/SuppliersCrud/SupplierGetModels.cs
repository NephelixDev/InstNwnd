namespace InstNwnd.Web.Data.Models.SupplierCrud
{
    public class SupplierGetModels
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
