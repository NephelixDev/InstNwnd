namespace InstNwnd.Web.Data.Models.CategoriesCrud
{
    public class CategoriesUpdateModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public DateTime ModifyDate { get; set; }

    }
}