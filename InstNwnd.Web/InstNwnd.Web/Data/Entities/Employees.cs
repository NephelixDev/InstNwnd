using InstNwnd.Web.Data.Core;

namespace InstNwnd.Web.Data.Entities
{
    public class Employees : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string TitleOfCourtesy { get; internal set; }
        public string HomePhone { get; internal set; }
        public string Extension { get; internal set; }
        public byte[] Photo { get; internal set; }
        public string PhotoPath { get; internal set; }
    }
}
