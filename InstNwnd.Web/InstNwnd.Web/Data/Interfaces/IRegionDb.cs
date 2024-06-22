using InstNwnd.Web.Data.Models.Region;
using InstNwnd.Web.Data.Models;
using InstNwnd.Web.Data.DbObjects;
using System.Collections.Generic;
namespace InstNwnd.Web.Data.Interfaces
{
    public interface IRegionDb
    {
        RegionGetModel GetRegion(int RegionID);
        List<RegionGetModel> GetRegion();

        void SaveRegion(RegionSaveModel Region);
        void UpdateRegion(RegionUpdateModel updateRegion);
        void RemoveRegion(RegionRemoveModel departmentRemove);
       
    }
}
