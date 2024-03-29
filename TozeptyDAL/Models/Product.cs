﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TozeptyDAL.Models;

public class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Product Quantity is required")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Product Description is required")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Product Category is required")]
    [Display(Name = "Product Category")]
    public int CategoryId { get; set; }  // Change to CategoryId

    [ForeignKey("CategoryId")]  // Ensure ForeignKey attribute refers to the correct property
    public Category Category { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
    public decimal Price { get; set; }

    //public HttpPostedFileBase ImageFile { get; set; }

    // Image file name (to store the file name in the database)
    public string ImageFileName { get; set; }

    //public IEnumerable<SelectListItem> Categories { get; set; }
    //(we shld create a database for this)
}
