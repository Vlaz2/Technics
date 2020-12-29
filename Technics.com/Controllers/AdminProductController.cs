using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Technics.com.Interfaces;
using Technics.com.Models;
using Technics.com.Services;
using Microsoft.AspNetCore.Http;
using Technics.com.Attributes;
using System.Threading.Tasks;

namespace Technics.com.Controllers
{
    [AuthorizedAttribute(Roles.Admin)]
    public class AdminProductController : Controller
    {
        private readonly IAllProducts productRep;
        private readonly IProductsCategory categoryRep;
        private readonly IManufacturer manufacturerRep;
        private readonly ServiceUser serviceUser;
        private readonly FilterService filterService;
        private readonly FileService fileService;

        public AdminProductController(IAllProducts productRep,
            IProductsCategory categoryRep,
            ServiceUser serviceUser,
            FilterService filterService,
            IManufacturer manufacturerRep,
            FileService fileService)
        {
            this.productRep = productRep;
            this.categoryRep = categoryRep;
            this.serviceUser = serviceUser;
            this.filterService = filterService;
            this.manufacturerRep = manufacturerRep;
            this.fileService = fileService;
        }

        public IActionResult UpdateProduct(int id, string message)
        {
            var product = productRep.GetObjectProduct(id);

            for (int i = product.Imgs.Count; i < 6; i++)
                product.Imgs.Add(new Photo());

            ViewBag.Category = categoryRep.GetAllSubcategories();
            ViewBag.Manufacture = manufacturerRep.GetAlIManufacturers().ToList();
            ViewBag.message = message;
            return View(product);
        }

        public async Task<IActionResult> UpdateProduct(Product productToUpdate)
        {
            await productRep.UpdateProductAsync(productToUpdate);
            return RedirectToAction("UpdateProduct", new { id = productToUpdate.Id, message = "Изменения сохранены" });
        }

        public IActionResult CreateProduct(string message)
        {
            ViewBag.message = message;
            ViewBag.Category = categoryRep.GetAllSubcategories();
            ViewBag.Manufacture = manufacturerRep.GetAlIManufacturers().ToList();
            return View();
        }

        public async Task<ActionResult> CreateProduct(Product product)
        {
            await productRep.CreateProductAsync(product);
            return RedirectToAction("CreateProduct", new { message = "Товар успешно создан" });
        }

        public async Task<ActionResult> DeleteProduct(int id)
        {
            await productRep.DeleteProductAsync(id);
            return RedirectToAction("List", "Products");
        }

        public ActionResult CreateProductsByFile(string message)
        {
            ViewBag.message = message;
            return View(); ;
        }

        public async Task<ActionResult> CreateProductsByFile(IFormFile uploadedFile)
        {
            if (uploadedFile == null)
                return BadRequest();

            List<Product> productsFromFile = fileService.ReadFile(uploadedFile);
            await productRep.CreateProductsFromFileAsync(productsFromFile);
            return RedirectToAction("CreateProductsByFile", new { message = "Товары добавлены" });
        }
    }
}