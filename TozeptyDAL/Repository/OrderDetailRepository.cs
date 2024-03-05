using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TozeptyDAL.Data;
using System.Data.Entity;
using TozeptyDAL.Interfaces;
using TozeptyDAL.Models;

namespace TozeptyDAL.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly FoodDbContext dbContext;

        public OrderDetailRepository(FoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            dbContext.OrderDetails.Add(orderDetail);
            dbContext.SaveChanges();
        }

        public OrderDetail GetOrderDetailById(int orderDetailId)
        {
            return dbContext.OrderDetails.Find(orderDetailId);
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return dbContext.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }

        public int GetOrderDetailByOrderId(int orderId)
        {
            var orderDetail = dbContext.OrderDetails
                  .FirstOrDefault(od => od.OrderId == orderId);
            return orderDetail.OrderStatus;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return dbContext.OrderDetails.ToList();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            dbContext.Entry(orderDetail).State = EntityState.Modified;
            dbContext.SaveChanges();
        }


        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            dbContext.OrderDetails.Remove(orderDetail);
            dbContext.SaveChanges();
        }

        public bool UpdateOrderStatus(int orderId, int status)
        {
            try
            {
                // Get all order details with the specified orderId
                List<OrderDetail> orderDetails = dbContext.OrderDetails.Where(od => od.OrderId == orderId).ToList();

                if (orderDetails.Any())
                {
                    // Update the OrderStatus for each order detail
                    foreach (var orderDetail in orderDetails)
                    {
                        orderDetail.OrderStatus = status;
                    }

                    // Save changes to the database
                    dbContext.SaveChanges();

                    // Return true indicating the update was successful
                    return true;
                }
                else
                {
                    // No order details found with the specified orderId
                    Console.WriteLine("No order details found for the specified orderId.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"Error updating order status: {ex.Message}");
                return false;
            }
        }
    }
}
