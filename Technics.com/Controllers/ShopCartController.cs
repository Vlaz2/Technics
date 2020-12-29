using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Technics.com.Repository;
using Technics.com.Services;
using Technics.com.ViewModels;

namespace Technics.com.Controllers
{
    public class ShopCartController:Controller
    {
        private readonly ShopCartRepository shopCartRep;
        private readonly ServiceCart servicesCart;

        public ShopCartController(ShopCartRepository shopCartRep, ServiceCart servicesCart)
        {
            this.shopCartRep = shopCartRep;
            this.servicesCart = servicesCart;
        }
       
        public IActionResult Delete(int id)
        {
            servicesCart.DeleteProd(id);
            return RedirectToAction("Index");
        }

        public IActionResult Index(string message)
        {
            var ids = servicesCart.GetCartItems();
            var items = shopCartRep.GetShopCartItems(ids);

            ProductsCartViewModel productsCart = new ProductsCartViewModel();
            productsCart.Products = items;
            productsCart.ProductsCount = items.Count;
            productsCart.Price = items.Sum(x => x.Price);

            ViewBag.message = message;
            return View(productsCart);
        }

        public IActionResult AddToCart(int id)
        {
            servicesCart.SetProduct(id);
            return Ok();
        }
    }
}
