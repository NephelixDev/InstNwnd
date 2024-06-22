using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.Region;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;

namespace InstNwnd.Web.Data.DbObjects
{
    public class RegionDb : IRegionDb
    {
        private readonly InstNwndContext context;

        public RegionDb(InstNwndContext context)
        {
            this.context = context;
        }

        private Region ValidateRegionExists(int regionId)
        {
            var region = context.Region.Find(regionId);
            if (region == null)
            {
                throw new RegionDbException($"No se encontró la región con el id {regionId}");
            }
            return region;
        }

        private static RegionGetModel MapToModel(Region entity)
        {
            return new RegionGetModel
            {
                RegionID = entity.RegionID,
                RegionDescription = entity.RegionDescription
            };
        }

        private Region MapToEntity(RegionSaveModel model)
        {
            
            var entity=new Region();
            entity.RegionID = model.RegionID;
            entity.RegionDescription = model.RegionDescription;

            
            return entity;
        }

        private void MapToEntity(RegionUpdateModel model, Region entity)
        {
            entity.RegionDescription = model.RegionDescription;
        }

        public List<RegionGetModel> GetRegion()
        {
            return context.Region
                .Select(region => MapToModel(region))
                .ToList();
        }

        public RegionGetModel GetRegion(int regionId)
        {
            var region = ValidateRegionExists(regionId);
            return MapToModel(region);
        }

        public void RemoveRegion(RegionRemoveModel regionRemove)
        {
            var region = ValidateRegionExists(regionRemove.RegionID);
            context.Region.Remove(region);
            context.SaveChanges();
        }

        public void SaveRegion(RegionSaveModel regionSave)
        {
            var region = MapToEntity(regionSave);
            context.Region.Add(region);
            context.SaveChanges();
        }

        public void UpdateRegion(RegionUpdateModel updateRegion)
        {
            var region = ValidateRegionExists(updateRegion.RegionID);
            MapToEntity(updateRegion, region);
            context.Region.Update(region);
            context.SaveChanges();
        }
    }
}
