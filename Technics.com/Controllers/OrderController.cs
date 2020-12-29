using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Technics.com.Attributes;
using Technics.com.Interfaces;
using Technics.com.Repository;
using Technics.com.Repository.Interfaces;
using Technics.com.Services;
using Technics.com.ViewModels;

namespace Technics.com.Controllers
{
    [AuthorizedAttribute]
    public class OrderController : Controller
    {
        private readonly IAllOrders orderRep;
        private readonly ShopCartRepository shopCartRep;
        private readonly ServiceCart servicesCart;
        private readonly ServiceUser servicesUser;
        private readonly IAllUser userRep;

        public OrderController(IAllOrders orderRep,
            ShopCartRepository shopCartRep,
            ServiceCart servicesCart,
            ServiceUser servicesUser,
            IAllUser userRep)
        {
            this.orderRep = orderRep;
            this.shopCartRep = shopCartRep;
            this.servicesCart = servicesCart;
            this.servicesUser = servicesUser;
            this.userRep = userRep;
        }

        public IActionResult GetOrders()
        {
            var user = servicesUser.GetUser();
            var orders = orderRep.GetOrdersByUserId(user.Id);

            if (orders.Count == 0)
            {
                ViewBag.message = "У вас нет заказов";
                return View();
            }

            List<OrderWithProductsViewModel> orderProducts = new List<OrderWithProductsViewModel>();

            foreach (var item in orders)
                orderProducts.Add(new OrderWithProductsViewModel { Order = item, Products = orderRep.GetProductsByOrderId(item.Id) });

            return View(orderProducts);
        }

        public IActionResult CreateOrder()
        {
            var user = servicesUser.GetUser();
            var ids = servicesCart.GetCartItems();
            var shopItems = shopCartRep.GetShopCartItems(ids);

            if (!orderRep.CheckProductsInStock(shopItems))
                return RedirectToAction("Index", "ShopCart", new { message = "К сожалению на складе нет товаров в таком количестве" });

            var orderWithCustomer = new OrderWithCustomerViewModel();
            orderWithCustomer.User = user;
            return View(orderWithCustomer);
        }

        public async Task<IActionResult> PostOrder(OrderWithCustomerViewModel orderWithCustomer)
        {
            var ids = servicesCart.GetCartItems();
            var shopItems = shopCartRep.GetShopCartItems(ids);

            if (!orderRep.CheckProductsInStock(shopItems))
                return RedirectToAction("ShopCart", "Index", new { message = "К сожалению на складе нет товаров в таком количестве" });

            await orderRep.CreateOrderAsync(orderWithCustomer.User, shopItems, orderWithCustomer.Order);
            servicesCart.Drop();
            return RedirectToAction("VariousInf", "Order", new { inf = "Заказ успешно создан" });
        }

        public IActionResult VariousInf(string inf)
        {
            ViewBag.Message = inf;
            return View();
        }

    }
}
