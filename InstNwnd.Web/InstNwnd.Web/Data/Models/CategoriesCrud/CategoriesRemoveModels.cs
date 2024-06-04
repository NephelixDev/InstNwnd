namespace InstNwnd.Web.Data.Models.CategoriesCrud
{
    public class CategoriesRemoveModels
    {
        public int CategoryId { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeleteDate { get; set; }
        public string? Description { get; set; }
        public byte[] Picture { get; internal set; }
    }
}
