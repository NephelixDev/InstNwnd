namespace InstNwnd.Web.Data.Models.CategoriesCrud
{
    public class BaseCategoriesModels
    {
        public int CategoryID { get; set; }


        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public byte[]? Picture { get; set; }
    }
}
