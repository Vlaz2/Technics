using System.Collections.Generic;
using System.Linq;
using Technics.com.Models;
using Technics.ViewModels;

namespace Technics.com.Services
{
    public class FilterService 
    {

        public PageInfo SetPageInfo(int page, int countProductsOnCategory)
        {
            var pageInfo = new PageInfo()
            {
                PageCurrent = page,
                PageSize = 8,
                TotalItems = countProductsOnCategory
            };
            return pageInfo;
        }

        public void SetParametrsOnPrice(List<Product> allProductsChosenCategory, ProductsListViewModel productObj, int currentMinP, int currentMaxP, string sortBy)
        {
            productObj.SortBy = sortBy;
            productObj.MinPriсe = allProductsChosenCategory.Min(x => x.Price);
            productObj.MaxPrice = allProductsChosenCategory.Max(x => x.Price);
            productObj.CurrentMaxPrice = productObj.MaxPrice;
            productObj.CurrentMinPrice = productObj.MinPriсe;

            if (currentMinP >= productObj.MinPriсe && currentMaxP <= productObj.MaxPrice)
            {
                productObj.CurrentMaxPrice = currentMaxP;
                productObj.CurrentMinPrice = currentMinP;
            }
        }

        public void SetProductsInfo(Category category, ProductsListViewModel productObj, List<Product> productsOnLoad)
        {
            if (category == null)
            {
                productObj.ProductsOnLoad = productsOnLoad;
                productObj.CurrentCategory = "Все товары";
            }
            else
            {
                productObj.ProductsOnLoad = productsOnLoad;
                productObj.CurrentCategory = category.CategoryName;
                productObj.CurrentCategoryId = category.Id;
            }
        }

    }
}
