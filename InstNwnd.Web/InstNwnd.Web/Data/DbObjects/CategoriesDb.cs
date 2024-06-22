using InstNwnd.Web.Data.Models.CategoriesCrud;
using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Entities;

namespace InstNwnd.Web.Data.DbObjects
{
    public class CategoriesDb : ICategoriesDb
    {
        private readonly InstNwndContext context;

        public CategoriesDb(InstNwndContext context)
        {
            this.context = context;
        }

        private Categories ValidateCategoryExists(int categoryId)
        {
            var category = this.context.Categories.Find(categoryId);

            if (category == null)
            {
                throw new CategoriesDbException("Esta categoría no se encuentra registrada.");
            }

            return category;
        }

        private static CategoriesGetModels MapToModel(Categories entity)
        {
            return new CategoriesGetModels
            {
                CategoryID = entity.CategoryID,
                CategoryName = entity.CategoryName,
                Description = entity.Description,
                Picture = entity.Picture
            };
        }

        private void MapToEntity(CategoriesUpdateModels model, Categories entity)
        {
            entity.CategoryID = model.CategoryID;
            entity.CategoryName = model.CategoryName;
            entity.Description = model.Description;
            entity.Picture = model.Picture;
        }

        private Categories MapToEntity(CategoriesSaveModels model)
        {
            Categories entity = new Categories
            {
                CategoryName = model.CategoryName,
                Description = model.Description,
                Picture = model.Picture
            };
            return entity;
        }

        public List<CategoriesGetModels> GetCategories()
        {
            return context.Categories.Select(category => MapToModel(category)).ToList();
        }

        public CategoriesGetModels GetCategory(int categoryId)
        {
            var category = ValidateCategoryExists(categoryId);
            return MapToModel(category);
        }

        public void RemoveCategory(CategoriesRemoveModels removeCategory)
        {
            var category = ValidateCategoryExists(removeCategory.CategoryID);
            this.context.Categories.Remove(category);
            this.context.SaveChanges();
        }

        public void SaveCategory(CategoriesSaveModels saveCategory)
        {
            var category = MapToEntity(saveCategory);
            this.context.Categories.Add(category);
            this.context.SaveChanges();
        }

        public void UpdateCategory(CategoriesUpdateModels updateCategory)
        {
            var category = ValidateCategoryExists(updateCategory.CategoryID);
            MapToEntity(updateCategory, category);
            context.Categories.Update(category);
            context.SaveChanges();
        }
    }
}
