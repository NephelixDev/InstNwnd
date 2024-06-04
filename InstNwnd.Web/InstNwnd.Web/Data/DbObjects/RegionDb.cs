using InstNwnd.Web.BL.Exceptions;
using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models;
using InstNwnd.Web.Data.Models.RegionCrud;
using System.Collections.Generic;
using System.Linq;

namespace InstNwnd.Web.Data.DbObjects
{
    public class RegionDb : IRegionDb
    {
        private readonly InstNwndContext context;

        public RegionDb(InstNwndContext context)
        {
            this.context = context;
        }

        public RegionModels GetRegion(int regionId)
        {
            var region = this.context.Region.Find(regionId);

            if (region == null)
            {
                throw new RegionException("Esta región no se encuentra registrada.");
            }

            RegionModels regionModel = new RegionModels()
            {
                RegionId = region.RegionID,
                RegionDescription = region.RegionDescription
            };

            return regionModel;
        }

        public List<RegionModels> GetRegions()
        {
            return this.context.Region.Select(r => new RegionModels()
            {
                RegionId = r.RegionID,
                RegionDescription = r.RegionDescription
            }).ToList();
        }

        public void RemoveRegion(RegionRemoveModels removeRegion)
        {
            var regionToDelete = this.context.Region.Find(removeRegion.RegionId);

            if (regionToDelete == null)
            {
                throw new RegionDbException("Esta región no se encuentra registrada.");
            }

            regionToDelete.Deleted = removeRegion.Deleted;

            this.context.Region.Update(regionToDelete);
            this.context.SaveChanges();
        }

        public void SaveRegion(RegionSaveModels saveRegion)
        {
            var region = new Region()
            {
                RegionID = saveRegion.RegionId,
                RegionDescription = saveRegion.RegionDescription
            };

            this.context.Region.Add(region);
            this.context.SaveChanges();
        }

        public void UpdateRegion(RegionUpdateModels updateRegion)
        {
            var regionToUpdate = this.context.Region.Find(updateRegion.RegionId);

            if (regionToUpdate == null)
            {
                throw new RegionException("Esta región no se encuentra registrada.");
            }

            regionToUpdate.RegionDescription = updateRegion.RegionDescription;
            regionToUpdate.ModifyDate = updateRegion.ModifyDate;

            this.context.Region.Update(regionToUpdate);
            this.context.SaveChanges();
        }
    }
}
