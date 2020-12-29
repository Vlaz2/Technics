using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Technics.com.Attributes;
using Technics.com.Enums;
using Technics.com.Interfaces;
using Technics.com.Repository.Interfaces;
using Technics.com.Services;
using Technics.com.ViewModels;

namespace Technics.com.Controllers
{
    [AuthorizedAttribute(Roles.Admin)]
    public class AdminOrderController : Controller
    {
        private readonly IAllOrders orderRep;
        private readonly ServiceUser servicesUser;
        private readonly IAllUser userRep;

        public AdminOrderController(IAllOrders orderRep, ServiceUser servicesUser, IAllUser userRep)
        {
            this.userRep = userRep;
            this.orderRep = orderRep;
            this.servicesUser = servicesUser;
        }

        
        public IActionResult GetOrdersBy(string by)
        {
            switch (by)
            {
                case GetOrderBy.NOT_SERVED_ORDERS:
                    return View("NotServedOrders", orderRep.GetNotServedOrders());
                case GetOrderBy.NOT_DELIVERED_ORDERS:
                    return View("NotDeliveredOrders", orderRep.GetNotDeliveredOrders());
                case GetOrderBy.DELIVERED_ORDERS:
                    return View("DeliveredOrders", orderRep.GetDeliveredOrders());
                default:
                    return BadRequest();
            }
        }

        
        public async Task<IActionResult> UpdateOrder(string by, int orderId)
        {
            var user = servicesUser.GetUser();
            var orderToUpdate = orderRep.ChangeOrderBy(by, orderId, user.Id);
            await orderRep.UpdateOrderAsync(orderToUpdate);
            return Ok();
        }

      
        public async Task<IActionResult> DeleteOrderById(int orderId)
        {
            await orderRep.DeleteOrderByIdAsync(orderId);
            return RedirectToAction("GetOrdersBy", GetOrderBy.NOT_SERVED_ORDERS);
        }

        
        public IActionResult ServedOrdersInformation()
        {
            var admins = userRep.GetAllUsers.Where(x => x.Role == Roles.Admin);
            List<ServedOrdersViewModel> servedOrders = new List<ServedOrdersViewModel>();

            foreach (var admin in admins)            
                servedOrders.Add(new ServedOrdersViewModel { User = admin, CountServedOrders = orderRep.GetServedOrdersByAdminId(admin.Id).Count() });
    
            return View(servedOrders);
        }
    }
}