using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TozeptyDAL.Data;
using TozeptyDAL.Interfaces;
using TozeptyDAL.Models;

namespace TozeptyDAL.Repository
{
    public class CategoryRepository : ICategoryRepository   
    {
        private readonly FoodDbContext dbContext;
        public CategoryRepository(FoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CategoryExists(string categoryName)
        {
            Category category = dbContext.Categories.FirstOrDefault(cat => cat.CategoryName == categoryName);
            if (category != null)
                return true;
            return false;
        }

        public bool CategoryExists(string categoryName, int id)
        {
            Category category = dbContext.Categories.FirstOrDefault(cat => cat.CategoryName == categoryName);
            if (category != null)
            {
                if (category.CategoryId == id) return false;
            }

            return true;

        }

        public void DeleteCategory(Category categoryToDelete)
        {
            dbContext.Categories.Remove(categoryToDelete);
            dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return dbContext.Categories;
        }

        public Category GetCategoryById(int id)
        {
            Category getCategory = dbContext.Categories.Find(id);
            return getCategory;
        }

        public int GetLastCategoryId()
        {
            int lastCategoryId = dbContext.Categories.Max(c => (int?)c.CategoryId) ?? 0;
            return lastCategoryId;
        }

        public int SaveCategory(Category category)
        {
            dbContext.Categories.Add(category);
            int res = dbContext.SaveChanges();
            return res;
        }

        public Category UpdateCategory(Category existingCategory)
        {
            Category updatecategory = dbContext.Categories.Find(existingCategory.CategoryId);
            if (updatecategory != null)
            {
                updatecategory.CategoryName = existingCategory.CategoryName;
                dbContext.SaveChanges();
            }
            return updatecategory;
        }

    }
}
