using InstNwnd.Web.Data.Models.Territories;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface ITerritoriesDb
    {
        TerritoriesGetModel GetTerritories(string TerritoryID);
        List<TerritoriesGetModel> GetTerritories(); 
        void RemoveTerritories(TerritoriesRemoveModel TerritoriesRemove);
        void SaveTerritories(TerritoriesSaveModel TerritoriesSave);
        void UpdateTerritories(TerritoriesUpdateModel updateTerritories);
    }
}
