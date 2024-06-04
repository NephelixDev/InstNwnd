namespace InstNwnd.Web.Data.Models.TerritoriesCrud
{
    public class TerritoriesUpdateModels
    {
        public int TerritoryId { get; set; }
        public string TerritoryName { get; set; }
        public int RegionId { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
