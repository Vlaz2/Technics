using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Technics.com.Attributes;
using Technics.com.Interfaces;
using Technics.com.Models;

namespace Technics.com.Controllers
{
    [AuthorizedAttribute(Roles.Admin)]
    public class AdminCategoryController : Controller
    {
        private readonly IProductsCategory categoryRep;

        public AdminCategoryController(IProductsCategory categoryRep)
        {
            this.categoryRep = categoryRep;
        }

        
        public IActionResult CreateCategoryWithStandartParent(string message)
        {
            ViewBag.NamesParentCategories = categoryRep.GetAllParentCategories().Select(x => x.CategoryName);
            ViewBag.message = message;
            return View();
        }

       
        public IActionResult CreateCategoryWithNewParent(string message)
        {
            ViewBag.message = message;
            return View();
        }

        
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (categoryRep.GetAllCategories().Any(x => x.CategoryName == category.ParentCategory.CategoryName))
            {
                 await categoryRep.CreateCategoryWithStandartParentAsync(category);
                 return RedirectToAction("CreateCategoryWithStandartParent",new { message = "Категория успешно создана" });
            }

            await categoryRep.CreateCategoryWithNewParentAsync(category);
            return RedirectToAction("CreateCategoryWithNewParent", new { message = "Категория успешно создана" });
        }
    }
}