using InstNwnd.Web.Data.Models.CategoriesCrud;
using System.Collections.Generic;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface ICategoriesDb
    {
        List<CategoriesBaseModels> GetCategories();
        CategoriesBaseModels GetCategories(int CategoriesId);
     
        void UpdateCategories(CategoriesUpdateModels CategoriesAdd);
        void RemoveCategories(CategoriesRemoveModels CategoriesAdd);
        void SaveCategories(CustomersSaveModels categoriesSaveModels);
    }
}
