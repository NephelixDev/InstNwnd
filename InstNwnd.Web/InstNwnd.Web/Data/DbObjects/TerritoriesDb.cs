using InstNwnd.Web.BL.Exceptions;
using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models;
using InstNwnd.Web.Data.Models.Territories;



namespace InstNwnd.Web.Data.DbObjects
{
    public class TerritoriesDb : ITerritoriesDb
    {
        private readonly InstNwndContext context;

        public TerritoriesDb(InstNwndContext context)
        {
            this.context = context;
        }
        public TerritoriesGetModel GetTerritories(int TerritoryID)
        {
            var Territories = this.context.Territories.Find(TerritoryID);

            if (Territories is null)
            {
                throw new TerritoriesDbException($"No se encontro el departamento con el id {TerritoryID}");
            }

            TerritoriesGetModel TerritoriesModel = new TerritoriesGetModel()
            {
                TerritoryID = Territories.TerritoryID,
                TerritoryDescription = Territories.TerritoryDescription,
            };

            return TerritoriesModel;
        }

        public List<TerritoriesGetModel> GetTerritories()
        {
            return this.context.Territories
                .Select(Territories  => new TerritoriesGetModel()
            {
                    TerritoryID = Territories.TerritoryID,
                TerritoryDescription = Territories.TerritoryDescription,
            }).ToList();
        }

       

        public void RemoveTerritories(TerritoriesRemoveModel TerritoriesRemove)
        {
            Territories TerritoriesToDelete = this.context.Territories.Find(TerritoriesRemove.TerritoryID);

            if (TerritoriesToDelete is null)
            {
                throw new TerritoriesDbException("El departamento no se encuentra registrado.");
            }


            

            this.context.Territories.Update(TerritoriesToDelete);

            this.context.SaveChanges();


        }

        public void SaveTerritories(TerritoriesSaveModel TerritoriesSave)
        {

            Territories Territories = new Territories()
            {
        
            };

            this.context.Territories.Add(Territories);
            this.context.SaveChanges();
        }

        public void UpdateTerritories(TerritoriesUpdateModel updateTerritories)
        {
            Territories TerritoriesToUpdate = this.context.Territories.Find(updateTerritories.TerritoryID);


            if (TerritoriesToUpdate is null)
            {
                throw new TerritoriesDbException("El departamento no se encuentra registrado.");
            }
        

            this.context.Territories.Update(TerritoriesToUpdate);
            this.context.SaveChanges();
        }
    }

}
