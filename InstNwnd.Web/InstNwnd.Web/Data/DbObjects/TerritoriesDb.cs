using InstNwnd.Web.BL.Exceptions;
using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models;
using InstNwnd.Web.Data.Models.TerritoriesCrud;
using System.Collections.Generic;
using System.Linq;

namespace InstNwnd.Web.Data.DbObjects
{
    public class TerritoriesDb : ITerritoriesDb
    {
        private readonly InstNwndContext context;

        public TerritoriesDb(InstNwndContext context)
        {
            this.context = context;
        }

        public TerritoriesModels GetTerritory(int territoryId)
        {
            var territory = this.context.Territories.Find(territoryId);

            if (territory == null)
            {
                throw new TerritoriesException("Este territorio no se encuentra registrado.");
            }

            TerritoriesModels territoryModel = new TerritoriesModels()
            {
                TerritoryId = territory.Id,
                TerritoryName = territory.TerritoryName,
                RegionId = territory.RegionId
            };

            return territoryModel;
        }

        public List<TerritoriesModels> GetTerritories()
        {
            return this.context.Territories.Select(t => new TerritoriesModels()
            {
                TerritoryId = t.Id,
                TerritoryName = t.TerritoryName,
                RegionId = t.RegionId
            }).ToList();
        }

        public void RemoveTerritory(TerritoriesRemoveModels removeTerritory)
        {
            Territories territoryToDelete = this.context.Territories.Find(removeTerritory.TerritoryId);

            if (territoryToDelete == null)
            {
                throw new TerritoriesDbException("Este territorio no se encuentra registrado.");
            }

            territoryToDelete.Deleted = removeTerritory.Deleted;

            this.context.Territories.Update(territoryToDelete);
            this.context.SaveChanges();
        }

        public void SaveTerritory(TerritoriesAddModels saveTerritory)
        {
            Territories territory = new Territories()
            {
                TerritoryName = saveTerritory.TerritoryName,
                RegionId = saveTerritory.RegionId
            };

            this.context.Territories.Add(territory);
            this.context.SaveChanges();
        }

        public void UpdateTerritory(TerritoriesRemoveModels updateTerritory)
        {
            Territories territoryToUpdate = this.context.Territories.Find(updateTerritory.TerritoryId);

            if (territoryToUpdate == null)
            {
                throw new TerritoriesException("Este territorio no se encuentra registrado.");
            }

            territoryToUpdate.TerritoryName = updateTerritory.TerritoryName;
            territoryToUpdate.RegionId = updateTerritory.RegionId;

            this.context.Territories.Update(territoryToUpdate);
            this.context.SaveChanges();
        }
    }
}
