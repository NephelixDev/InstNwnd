namespace InstNwnd.Web.Data.Models.CategoriesCrud
{
    public class CategoriesGetModels
    {


        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
