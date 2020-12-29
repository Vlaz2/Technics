using System.Collections.Generic;
using System.Threading.Tasks;
using Technics.com.Models;

namespace Technics.com.Interfaces
{
    public interface IProductsCategory
    {
        List<Category> GetAllCategories();

        Category GetCategoryByName(string name);

        Category GetCategoryById(long id);

        List<Category> GetAllParentCategories();

        List<Category> GetAllSubcategories();

        Task CreateCategoryWithNewParentAsync(Category category);

        Task CreateCategoryWithStandartParentAsync(Category category);
    }
}
