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
    public class CartRepository : ICartRepository
    {
        private readonly FoodDbContext dbContext;

        public CartRepository(FoodDbContext context)
        {
            dbContext = context;
        }


        public bool cartStatus()
        {
            return dbContext.ChangeTracker.HasChanges();
        }
        public Cart GetCartItemByCartIdAndCustomerId(int cartId, int customerId)
        {
            return dbContext.Carts
                .FirstOrDefault(c => c.CartId == cartId && c.CustomerId == customerId);
        }
        public List<Cart> GetCartItemsByCustomerId(int? customerId)
        {
            return dbContext.Carts
                .Where(c => c.CustomerId == customerId)
                .ToList();
        }
        //public Cart GetCartItemByProductIdAndCustomerId(int productId, int customerId)
        //{
        //    return dbContext.Carts
        //        .FirstOrDefault(c => c.ProductId == productId && c.CustomerId == customerId);
        //}
        // Create
        public Cart CreateCartItem(Cart cartItem)
        {
            var savedItem = dbContext.Carts.Add(cartItem);
            dbContext.SaveChanges();
            return savedItem;
        }

        // Read
        public Cart GetCartItemById(int cartItemId)
        {
            return dbContext.Carts.Find(cartItemId);
        }
        public IEnumerable<Cart> GetCartItemById(int[] cartIds)
        {
            return dbContext.Carts.Where(c => cartIds.Contains(c.CartId)).ToList();
        }
        public IEnumerable<Cart> GetAllCartItems()
        {
            return dbContext.Carts.ToList();
        }

        // Update
        public Cart UpdateCartItem(Cart cartItem)
        {
            var existingCartItem = dbContext.Carts.Find(cartItem.CartId);

            if (existingCartItem != null)
            {
                // Update the properties of the existing cart item with the values from the input cart item
                
                existingCartItem.CustomerId = cartItem.CustomerId;
                existingCartItem.ProductName = cartItem.ProductName;
                existingCartItem.Quantity = cartItem.Quantity;
                existingCartItem.Price = cartItem.Price;
                existingCartItem.ProductId = cartItem.ProductId;

                dbContext.SaveChanges();
            }

            return existingCartItem;
        }

        // Delete
        public Cart DeleteCartItem(int cartItemId)
        {
            var cartItem = dbContext.Carts.Find(cartItemId);

            if (cartItem != null)
            {
                dbContext.Carts.Remove(cartItem);
                dbContext.SaveChanges();
            }

            return cartItem;
        }
        public int cartSaveChanges()
        {
            return dbContext.SaveChanges();
        }


        public void DeleteCartItems(List<Cart> cartItems)
        {
            foreach (var cartItem in cartItems)
            {
                var existingCartItem = dbContext.Carts.Find(cartItem.CartId);

                if (existingCartItem != null)
                {
                    dbContext.Carts.Remove(existingCartItem);
                }
            }

            dbContext.SaveChanges();
        }

        public Cart RemoveCartItem(Cart cartItem)
        {
            var existingCartItem = dbContext.Carts.Find(cartItem.CartId);

            if (existingCartItem != null)
            {
                dbContext.Carts.Remove(existingCartItem);
                dbContext.SaveChanges();
                return existingCartItem;
            }
            return null;
        }
    }
}
