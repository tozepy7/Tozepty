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
        // Method to create an order
        void CreateOrder(Order order);

        // Another method to create an order with a different signature
        Order CreateOrder2(Order order);

        // Method to get an order by its ID
        Order GetOrderById(int orderId);

        // Method to get all orders
        IEnumerable<Order> GetAllOrders();

        // Method to update an order
        void UpdateOrder(Order order);

        // Method to delete an order
        void DeleteOrder(Order order);

        // Method to get orders by customer ID
        IEnumerable<Order> GetOrdersByCustomerId(int userId);

        // Method to get incomplete orders
        IEnumerable<Order> GetIncompleteOrders();
    }
}
