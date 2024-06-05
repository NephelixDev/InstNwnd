namespace InstNwnd.Web.Data.Core
{
    public abstract class BaseEntity
    {
        public int Id { get; set; } // Primary Key
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; } 

        // Campos comunes de dirección
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        // Campos comunes de información de contacto
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
