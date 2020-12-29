using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Technics.com.Attributes;
using Technics.com.Enums;
using Technics.com.Interfaces;
using Technics.com.Models;
using Technics.com.Services;
using Technics.ViewModels;

namespace Technics.com.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAllProducts productRep;
        private readonly IProductsCategory categoryRep;
        private readonly ServiceUser serviceUser;
        private readonly FilterService filterService;
        private readonly IComment commentRep;
        List<Product> allProductsChosenCategory;

        public ProductsController(IAllProducts productRep,
            IProductsCategory categoryRep,
            ServiceUser serviceUser,
            FilterService filterService,
            IComment commentRep)
        {
            this.productRep = productRep;
            this.categoryRep = categoryRep;
            this.serviceUser = serviceUser;
            this.filterService = filterService;
            this.commentRep = commentRep;
        }

        public IActionResult List(int currentMinPrice = 0, int currentMaxPrice = 0,int manufactureId = 0, int categoryId = 0, int page = 1,string sortBy = SortPrice.POPULAR)
        {
            if (manufactureId != 0)
                if (serviceUser.IsAllowedToSetManufacturerById(manufactureId)) 
                    serviceUser.SetManufacturers(manufactureId);
                
            ProductsListViewModel productObj = new ProductsListViewModel();
            productObj.ChosenManufacturersId = serviceUser.GetManufacturers();
            List<Product> allProductsChosenCategory = productRep.GetProductsByCategoryId(categoryId).ToList();

            if (allProductsChosenCategory.Count == 0)
                return BadRequest();

            productObj.AllManufacturersChosenCategory = allProductsChosenCategory.Select(x => x.Manufacturer).Select(x => x.Id).Distinct().ToList();

            if (productObj.ChosenManufacturersId.Count() != 0)
                allProductsChosenCategory = productRep.GetProductsByManufacturesId(productObj.ChosenManufacturersId, allProductsChosenCategory.ToList());


            filterService.SetParametrsOnPrice( allProductsChosenCategory, productObj, currentMinPrice,currentMaxPrice,sortBy);
            allProductsChosenCategory = productRep.GetProductsByPrice(currentMaxPrice, currentMinPrice, allProductsChosenCategory,sortBy);
            productObj.PageInfo = filterService.SetPageInfo(page, allProductsChosenCategory.Count());
            List<Product> productsOnLoad = allProductsChosenCategory.Skip((page-1) * productObj.PageInfo.PageSize)
                                                                    .Take(productObj.PageInfo.PageSize).ToList();
            filterService.SetProductsInfo(categoryRep.GetCategoryById(categoryId),productObj,productsOnLoad);
            return View(productObj);
        }

        public IActionResult ListForAjaxRequest(int currentMinPrice = 0, int currentMaxPrice = 0, int manufactureId = 0, int categoryId = 0, int page = 1, string sortBy = SortPrice.POPULAR)
        {
            if (manufactureId != 0)
                if (serviceUser.IsAllowedToSetManufacturerById(manufactureId))
                    serviceUser.SetManufacturers(manufactureId);

            ProductsListViewModel productObj = new ProductsListViewModel();
            productObj.ChosenManufacturersId = serviceUser.GetManufacturers();
            allProductsChosenCategory = productRep.GetProductsByCategoryId(categoryId).ToList();

            if (allProductsChosenCategory.Count == 0)
                return BadRequest();

            productObj.AllManufacturersChosenCategory = allProductsChosenCategory.Select(x => x.Manufacturer).Select(x => x.Id).Distinct().ToList();

            if (productObj.ChosenManufacturersId.Count() != 0)
                allProductsChosenCategory = productRep.GetProductsByManufacturesId(productObj.ChosenManufacturersId, allProductsChosenCategory.ToList());


            filterService.SetParametrsOnPrice(allProductsChosenCategory, productObj, currentMinPrice, currentMaxPrice, sortBy);
            allProductsChosenCategory = productRep.GetProductsByPrice(currentMaxPrice, currentMinPrice, allProductsChosenCategory, sortBy);
            productObj.PageInfo = filterService.SetPageInfo(page, allProductsChosenCategory.Count());
            List<Product> productsOnLoad = allProductsChosenCategory.Skip((page - 1) * productObj.PageInfo.PageSize)
                                                                    .Take(productObj.PageInfo.PageSize).ToList();
            filterService.SetProductsInfo(categoryRep.GetCategoryById(categoryId), productObj, productsOnLoad);
            return View("Products", productObj);
        }

        public IActionResult DropManufacturers(int _categoryId = 0)
        {
            serviceUser.DeleteManufacturesId();
            return RedirectToAction("List", "Products", new { categoryId = _categoryId });
        }

        public IActionResult Product(int id)
        {
            var product = productRep.GetObjectProduct(id);
            return View(product);
        }

        [AuthorizedAttribute]
        public async Task<IActionResult> AddComment(string message, int productId)
        {
            var user = serviceUser.GetUser();
            await commentRep.AddCommentAsync(message, productId, user.Id);
            return RedirectToAction("Product", new { id = productId });
        }
    }
}
