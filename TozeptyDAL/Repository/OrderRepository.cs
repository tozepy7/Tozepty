using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TozeptyDAL.Data;
using TozeptyDAL.Interfaces;
using TozeptyDAL.Models;

namespace TozeptyDAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodDbContext dbContext;

        public OrderRepository(FoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateOrder(Order order)
        {
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }

        public Order CreateOrderAndReturnStatus(Order order)
        {
            var result = dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            return result;
        }

        public void DeleteOrder(Order order)
        {
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return dbContext.Orders.ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return dbContext.Orders.Find(orderId);
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int userId)
        {
            IEnumerable<Order> orders = dbContext
                .Orders.Include(o => o.OrderDetails)
                .Where(o => o.CustomerID == userId)
                .ToList();

            return orders;
        }

        public IEnumerable<Order> GetOrdersWithPendingPaymentStatus()
        {
            IEnumerable<Order> orders = dbContext
                .Orders.Where(o => o.PaymentStatus == "PENDING")
                .ToList();
            return orders;
        }

        public void UpdateOrder(Order order)
        {
            dbContext.Entry(order).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void UpdatePaymentStatus(int orderId, string newPaymentStatus)
        {
            // Find the order by its ID
            Order orderToUpdate = dbContext.Orders.Find(orderId);

            if (orderToUpdate != null)
            {
                // Update the payment status
                orderToUpdate.PaymentStatus = newPaymentStatus;

                // Save changes to the database
                dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Order not found.");
            }
        }
    }
}
