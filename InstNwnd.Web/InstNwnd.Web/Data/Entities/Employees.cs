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
    }
}
