using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TozeptyDAL.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        //[Index(IsUnique = true)]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        // Navigation property
        public ICollection<Product> Products { get; set; }
    }
}
