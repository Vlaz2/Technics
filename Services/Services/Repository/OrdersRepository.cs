using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technics.com.Enums;
using Technics.com.Interfaces;
using Technics.com.Models;

namespace Technics.com.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContext appDbContext;

        public OrdersRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public bool CheckProductsInStock(List<Product> products)
        {
            foreach (var product in products.Distinct())
            {
                var count = products.Count(x => x.Id == product.Id);

                if (appDbContext.Products.FirstOrDefault(x=>x.Id == product.Id).AmountInStock - count < 0)
                    return false;
            }

            return true;
        }

        public async Task CreateOrderAsync(User user, List<Product> shopCartItems,Order _order)
        {
            Order order = new Order()
            {
                UserId = user.Id,
                OrderTime = DateTime.Now,
                Price = shopCartItems.Sum(x => x.Price),
                PaymentMethod = _order.PaymentMethod,
                ToTown = _order.ToTown,
                PostCode = _order.PostCode
            };
            await appDbContext.Orders.AddAsync(order);

            foreach (var el in shopCartItems.Distinct())
            {
                appDbContext.Products.FirstOrDefault(x => x.Id == el.Id).AmountInStock -=  shopCartItems.Count(x => x.Id == el.Id);
                ProductOrder productOrder = new ProductOrder()
                {
                    Order = order,
                    ProductId = el.Id,
                    Count = shopCartItems.Count(x => x.Id == el.Id)
                };
                await appDbContext.ProductsOrders.AddAsync(productOrder);
            }

            await appDbContext.SaveChangesAsync();
        }

        public Order GetOrderById(long id)
        {
            return appDbContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetAllOrders()
        {
            return appDbContext.Orders.Include(x => x.ProductsOrders).ThenInclude(x => x.Product).Include(x=>x.User).ToList();
        }

        public List<Order> GetNotServedOrders()
        {
            return GetAllOrders().Where(x => x.ConfirmOrder == false ||
            x.Paid == false && x.PaymentMethod == PaymentMethod.NowToABankCard).ToList();
        }

        public List<Order> GetOrdersByUserId(long id)
        {
            return GetAllOrders().Where(x => x.UserId == id).ToList();
        }

        public List<Product> GetProductsByOrderId(long orderId)
        {
            return appDbContext.ProductsOrders.Where(x => x.OrderId == orderId).Include(x => x.Product).Select(x => x.Product).ToList();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            appDbContext.Orders.Update(order);
            await appDbContext.SaveChangesAsync();
        }

        public List<Order> GetServedOrdersByAdminId(long id)
        {
            return GetAllOrders().Where(x => x.AttendantAdminId == id).ToList();
        }

        public async Task DeleteOrderByIdAsync(long id)
        {
            appDbContext.Orders.Remove(GetAllOrders().FirstOrDefault(x => x.Id == id));
            await appDbContext.SaveChangesAsync();
        }

        public List<Order> GetNotDeliveredOrders()
        {
            return GetAllOrders().Where(x => x.AttendantAdminId != 0 && x.Delivered == false).ToList();
        }

        public List<Order> GetDeliveredOrders()
        {
            return GetAllOrders().Where(x => x.AttendantAdminId != 0 && x.Delivered == true).ToList();
        }

        public Order ChangeOrderBy(string by, long orderId, long attendantAdminId)
        {
            var orderToUpdate = GetAllOrders().FirstOrDefault(x=>x.Id == orderId);

            switch (by)
            {
                case ChangeOrder.CONFIRM:
                    orderToUpdate.ConfirmOrder = !orderToUpdate.ConfirmOrder;
                    orderToUpdate.AttendantAdminId = 0;
                    break;
                case ChangeOrder.PAID:
                    orderToUpdate.Paid = !orderToUpdate.Paid;
                    orderToUpdate.AttendantAdminId = 0;
                    break;
                case ChangeOrder.DELIVERED:
                    orderToUpdate.Delivered = !orderToUpdate.Delivered;
                    if (orderToUpdate.PaymentMethod == PaymentMethod.UponReceipt)
                        orderToUpdate.Paid = orderToUpdate.Delivered;
                    break;
                default:
                    break;
            }

            if (orderToUpdate.Paid == true && orderToUpdate.ConfirmOrder == true ||
                orderToUpdate.PaymentMethod == PaymentMethod.UponReceipt && orderToUpdate.ConfirmOrder == true)
                orderToUpdate.AttendantAdminId = attendantAdminId;

            return orderToUpdate;
        }
    }
}
