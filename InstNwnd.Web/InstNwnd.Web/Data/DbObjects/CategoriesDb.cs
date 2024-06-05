using InstNwnd.Web.BL.Exceptions;
using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.CategoriesCrud;



namespace InstNwnd.Web.Data.DbObjects
{
    public class CategoriesDb : ICategoriesDb
    {
        private readonly InstNwndContext context;

        public CategoriesDb(InstNwndContext context)
        {
            this.context = context;
        }

        public CategoriesModels GetCategory(int categoryId)
        {
            var category = this.context.Categories.Find(categoryId);

            if (category == null)
            {
                throw new CategoriesException("Esta categoría no se encuentra registrada.");
            }

            CategoriesModels categoryModel = new CategoriesModels()
            {
                CategoryId = category.Id,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            };

            return categoryModel;
        }

        public List<CategoriesModels> GetCategories()
        {
            return this.context.Categories.Select(c => new CategoriesModels()
            {
                CategoryId = c.Id,
                CategoryName = c.CategoryName,
                Description = c.Description,
                Picture = c.Picture
            }).ToList();
        }

        public void RemoveCategory(CategoriesRemoveModels removeCategory)
        {
            Categories categoryToDelete = this.context.Categories.Find(removeCategory.CategoryId);

            if (categoryToDelete == null)
            {
                throw new CategoriesDbException("Esta categoría no se encuentra registrada.");
            }

            categoryToDelete.Deleted = removeCategory.Deleted;
           

            this.context.Categories.Update(categoryToDelete);
            this.context.SaveChanges();
        }

        public void SaveCategory(CategoriesAddModels saveCategory)
        {
            Categories category = new Categories()
            {
                CategoryName = saveCategory.CategoryName,
                Description = saveCategory.Description,
                Picture = saveCategory.Picture,
              
            };
            this.context.Categories.Add(category);
            this.context.SaveChanges();
        }

        public void UpdateCategory(CategoriesRemoveModels updateCategory)
        {
            Categories categoryToUpdate = this.context.Categories.Find(updateCategory.CategoryId);

            if (categoryToUpdate == null)
            {
                throw new CategoriesException("Esta categoría no se encuentra registrada.");
            }

            
            categoryToUpdate.Description = updateCategory.Description;
            categoryToUpdate.Picture = updateCategory.Picture;
            

            this.context.Categories.Update(categoryToUpdate);
            this.context.SaveChanges();
        }
    }
}
