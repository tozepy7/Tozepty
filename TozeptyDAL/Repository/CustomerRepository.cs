using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TozeptyDAL.Data;
using TozeptyDAL.Interfaces;
using TozeptyDAL.Models;

namespace TozeptyDAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FoodDbContext dbContext;

        public CustomerRepository(FoodDbContext context)
        {
            dbContext = context;
        }

        public Customer GetCustomerByUserName(string userName)
        {
            return dbContext.Customers.FirstOrDefault(x => x.UserName == userName);
        }
        // Create
        public Customer CreateCustomer(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            return customer;
        }
       

        // Read
        public Customer GetCustomerById(int customerId)
        {
            return dbContext.Customers.Find(customerId);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return dbContext.Customers.ToList();
        }


        //public Cart GetCartItemByProductIdAndCustomerId(int productId, int customerId)
        //{
        //    return dbContext.Carts
        //        .FirstOrDefault(c => c.ProductId == productId && c.CusomerId == customerId);
        //}

        // Update
        public Customer UpdateCustomer(Customer customer)
        {
            var existingCustomer = dbContext.Customers.Find(customer.Id);

            if (existingCustomer != null)
            {
                // Update the properties of the existing customer with the values from the input customer
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.UserName = customer.UserName;
                existingCustomer.Password = customer.Password;
                existingCustomer.RoleId = customer.RoleId;    
                existingCustomer.Address = customer.Address;

                dbContext.SaveChanges();
            }

            return existingCustomer;
        }

        // Update address
        
        public bool UpdateCustomerAddressById(int customerId, string address)
        {
            var customer = dbContext.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                customer.Address = address;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        // Delete
        public Customer DeleteCustomer(int customerId)
        {
            var customer = dbContext.Customers.Find(customerId);

            if (customer != null)
            {
                dbContext.Customers.Remove(customer);
                dbContext.SaveChanges();
            }

            return customer;
        }

        public int customerSAveChanges()
        {
            return dbContext.SaveChanges();
        }
        public bool CustomerExists(string userName)
        {
            return dbContext.Customers.Any(a => a.UserName == userName);
        }

        public bool CustomerExistsEmail(string Email)
        {
            return dbContext.Customers.Any(a => a.Email == Email);
        }

        public Customer GetCustomerByUserNamePhone(string UserName, string PhoneNumber)
        {
            return dbContext.Customers.FirstOrDefault(a => a.UserName == UserName && a.PhoneNumber == PhoneNumber);
        }
        public bool CustomerExistsEmail(string UserEmail, int id)
        {
            var veriefyUser = dbContext.Customers.FirstOrDefault(a => a.Email == UserEmail);

            if (veriefyUser != null && veriefyUser.Id != id)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
