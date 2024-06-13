using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.CategoriesCrud;
using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using System.Collections.Generic;
using System.Linq;
using InstNwnd.Web.BL.Exceptions;

namespace InstNwnd.Web.Data.DbObjects
{
    public class CategoriesDb : ICategoriesDb
    {
        private readonly InstNwndContext context;

        public CategoriesDb(InstNwndContext context)
        {
            this.context = context;
        }

        public List<CategoriesBaseModels> GetCategories()
        {
            return this.context.Categories.Select(c => new CategoriesBaseModels()
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description,
                Picture = c.Picture
            }).ToList();
        }

        public CategoriesBaseModels GetCategories(int categoryId)
        {
            var category = this.context.Categories.Find(categoryId);

            if (category == null)
            {
                throw new CategoriesException("Esta categoría no se encuentra registrada.");
            }

            return new CategoriesBaseModels()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            };
        }

        public void SaveCategories(CustomersSaveModels categoriesSaveModels)
        {
            Categories category = new Categories()
            {
                CategoryName = categoriesSaveModels.CategoryName,
                Description = categoriesSaveModels.Description,
                Picture = categoriesSaveModels.Picture
            };
            this.context.Categories.Add(category);
            this.context.SaveChanges();
        }

        public void UpdateCategories(CategoriesUpdateModels categoriesUpdate)
        {
            Categories categoryToUpdate = this.context.Categories.Find(categoriesUpdate.CategoryId);

            if (categoryToUpdate == null)
            {
                throw new CategoriesException("Esta categoría no se encuentra registrada.");
            }

            categoryToUpdate.CategoryName = categoriesUpdate.CategoryName;
            categoryToUpdate.Description = categoriesUpdate.Description;
            categoryToUpdate.Picture = categoriesUpdate.Picture;

            this.context.Categories.Update(categoryToUpdate);
            this.context.SaveChanges();
        }

        public void RemoveCategories(CategoriesRemoveModels categoriesRemove)
        {
            Categories categoryToDelete = this.context.Categories.Find(categoriesRemove.CategoryId);

            if (categoryToDelete == null)
            {
                throw new CategoriesException("Esta categoría no se encuentra registrada.");
            }

            // Asignar la propiedad Deleted y luego actualizar
            categoryToDelete.Deleted = categoriesRemove.Deleted;

            this.context.Categories.Update(categoryToDelete);
            this.context.SaveChanges();
        }
    }
}
