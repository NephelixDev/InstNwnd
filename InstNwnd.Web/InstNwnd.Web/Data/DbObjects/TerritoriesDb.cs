using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.Territories;
using Microsoft.EntityFrameworkCore;

namespace InstNwnd.Web.Data.DbObjects
{
    public class TerritoriesDb : ITerritoriesDb
    {
        private readonly InstNwndContext context;

        public TerritoriesDb(InstNwndContext context)
        {
            this.context = context;
        }

        private Territories ValidateTerritoryExists(string territoryID)
        {
            var territory = context.Territories.Find(territoryID);
            if (territory == null)
            {
                throw new TerritoriesDbException($"No se encontró el territorio con el id {territoryID}");
            }
            return territory;
        }

        private static TerritoriesGetModel MapToModel(Territories entity)
        {
            return new TerritoriesGetModel
            {
                TerritoryID = entity.TerritoryID,
                TerritoryDescription = entity.TerritoryDescription,
                RegionID = entity.RegionID
            };
        }

        private Territories MapToEntity(TerritoriesSaveModel model)
        {
            var entity = new Territories
            {
                TerritoryID = model.TerritoryID,
                TerritoryDescription = model.TerritoryDescription,
                RegionID = model.RegionID
            };
            return entity;
        }

        private void MapToEntity(TerritoriesUpdateModel model, Territories entity)
        {
            entity.TerritoryDescription = model.TerritoryDescription;
            entity.RegionID = model.RegionID;
        }

        public List<TerritoriesGetModel> GetTerritories()
        {
            return context.Territories
                .Select(territory => MapToModel(territory))
                .ToList();
        }

        public TerritoriesGetModel GetTerritories(string territoryID)
        {
            var territory = ValidateTerritoryExists(territoryID);
            return MapToModel(territory);
        }

        public void RemoveTerritories(TerritoriesRemoveModel territoryRemove)
        {
            var territory = ValidateTerritoryExists(territoryRemove.TerritoryID);
            context.Territories.Remove(territory);
            context.SaveChanges();
        }

        public void SaveTerritories(TerritoriesSaveModel territorySave)
        {
            var territory = MapToEntity(territorySave);
            context.Territories.Add(territory);
            context.SaveChanges();
        }

        public void UpdateTerritories(TerritoriesUpdateModel updateTerritory)
        {
            var territory = ValidateTerritoryExists(updateTerritory.TerritoryID);
            MapToEntity(updateTerritory, territory);
            context.Territories.Update(territory);
            context.SaveChanges();
        }
    }
}
