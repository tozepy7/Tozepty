using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TozeptyDAL.Models;

namespace TozeptyDAL.Interfaces
{
    public interface IProductRepository
    {

        int SaveProductChanges();
        Product CreateProduct(Product product);
        Product GetProductById(int productId);
        IEnumerable<Product> GetAllProducts();

        Product UpdateProduct(Product product);

        Product DeleteProduct(int productId);

        //write need to implement delete all functionalities
    }
}

