using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technics.com.Models;

namespace Technics.com.Interfaces
{
    public interface IAllOrders
    {
        List<Order> GetAllOrders();
        Order GetOrderById(long id);
        Task UpdateOrderAsync(Order order);
        Task CreateOrderAsync(User user,List<Product> shopCartItems,Order order);
        List<Order> GetOrdersByUserId(long id);
        List<Product> GetProductsByOrderId(long orderId);
        List<Order> GetNotServedOrders();
        List<Order> GetServedOrdersByAdminId(long id);
        List<Order> GetNotDeliveredOrders();
        List<Order> GetDeliveredOrders();
        Order ChangeOrderBy(string by, long orderId, long attendantAdminId);
        Task DeleteOrderByIdAsync(long id);
        bool CheckProductsInStock(List<Product> products);
    }
}
