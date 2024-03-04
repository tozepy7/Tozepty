using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TozeptyDAL.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product Quantity is required")]
        public int ProductQuantity { get; set; }

        [Required(ErrorMessage = "Product Description is required")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Product Category is required")]
        [Display(Name = "Product Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }

        // Image file name (to store the file name in the database)
        public string ImageFileName { get; set; }
        //public IEnumerable<SelectListItem> Categories { get; set; }
        //(we shld create database for this)

    }
}
