using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technics.com.Interfaces;
using Technics.com.Models;

namespace Technics.Repository
{
    public class CategoryRepository:IProductsCategory
    {
        private readonly AppDbContext appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Category GetCategoryById(long id)
        {
            return appDbContext.Categories.FirstOrDefault(x=>x.Id==id);
        }

        public Category GetCategoryByName(string name)
        {
            return appDbContext.Categories.FirstOrDefault(x=>x.CategoryName == name);
        }

        public async Task CreateCategoryWithNewParentAsync(Category category)
        {
            await appDbContext.Categories.AddAsync(category.ParentCategory);
            await appDbContext.Categories.AddAsync(category);
            await appDbContext.SaveChangesAsync();
        }

        public async Task CreateCategoryWithStandartParentAsync(Category category)
        {
            var parrent = appDbContext.Categories.FirstOrDefault(x => x.CategoryName == category.ParentCategory.CategoryName);
            category.ParentCategoryId = parrent.Id;
            await appDbContext.Categories.AddAsync(category);
            await appDbContext.SaveChangesAsync();
        }

        public List<Category> GetAllParentCategories()
        {
            return appDbContext.Categories.Where(x => x.ParentCategoryId == null).ToList();
        }

        public List<Category> GetAllSubcategories()
        {
            return appDbContext.Categories.Where(x => x.ParentCategoryId != null).ToList();
        }

        public List<Category> GetAllCategories()
        {
           return appDbContext.Categories.ToList();
        }
    }
}
