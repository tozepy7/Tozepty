using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TozeptyDAL.Models;

namespace TozeptyDAL.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        Order CreateOrderAndReturnStatus(Order order);
        Order GetOrderById(int orderId);
        IEnumerable<Order> GetAllOrders();
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        IEnumerable<Order> GetOrdersByCustomerId(int userId);
        void UpdatePaymentStatus(int orderId, string newPaymentStatus);
        IEnumerable<Order> GetOrdersWithPendingPaymentStatus();
    }
}
