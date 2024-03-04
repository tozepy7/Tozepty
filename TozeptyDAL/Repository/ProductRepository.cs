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
    public class ProductRepository : IProductRepository
    {
        private readonly FoodDbContext dbContext;

        public ProductRepository(FoodDbContext context)
        {
            this.dbContext = context;
        }

        // Create
        public Product CreateProduct(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return product;
        }


        // Read
        public Product GetProductById(int productId)
        {
            return dbContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products.ToList();

        }

        // Update
        public Product UpdateProduct(Product product)
        {
            var existingProduct = dbContext.Products.Find(product.ProductId);

            if (existingProduct != null)
            {
                // Update the properties of the existing product with the values from the input product
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.ImageFileName = product.ImageFileName;

                dbContext.SaveChanges();
            }

            return existingProduct;
        }

        // Delete
        public Product DeleteProduct(int productId)
        {
            var product = dbContext.Products.Find(productId);

            if (product != null)
            {
                dbContext.Products.Remove(product);
                dbContext.SaveChanges();
            }

            return product;
        }
        public int SaveProductChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
