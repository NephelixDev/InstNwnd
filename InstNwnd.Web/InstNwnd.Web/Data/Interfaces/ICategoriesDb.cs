using InstNwnd.Web.Data.Models.CategoriesCrud;
using System.Collections.Generic;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface ICategoriesDb
    {
        List<CategoriesGetModels> GetCategories();
        CategoriesGetModels GetCategory(int categoryId);
        void SaveCategory(CategoriesSaveModels saveCategory);
        void UpdateCategory(CategoriesUpdateModels updateCategory);
        void RemoveCategory(CategoriesRemoveModels removeCategory);
    }
}
