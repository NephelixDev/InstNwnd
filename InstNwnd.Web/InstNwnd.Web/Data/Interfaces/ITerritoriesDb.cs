using InstNwnd.Web.Data.Models.Territories;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface ITerritoriesDb
    {
        TerritoriesGetModel GetTerritories(int TerritoryID);
        List<TerritoriesGetModel> GetTerritories(); // Método que causa el error
        void RemoveTerritories(TerritoriesRemoveModel TerritoriesRemove);
        void SaveTerritories(TerritoriesSaveModel TerritoriesSave);
        void UpdateTerritories(TerritoriesUpdateModel updateTerritories);
    }
}
