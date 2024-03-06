using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tozepty.Models
{
    public class OrderDetailsViewModel
    {
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid quantity")]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
        public int ProductId { get; set; }
        public int OrderStatus { get; set; }
    }
}