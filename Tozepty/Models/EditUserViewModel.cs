﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tozepty.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50)]
        [RegularExpression(@"^[A-Za-z]{3,15}$", ErrorMessage = "Only contain character")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50)]
        [RegularExpression(@"^[A-Za-z]{3,15}$", ErrorMessage = "Only contain character")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[6-9][0-9]{9}$", ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(255)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z0-9_-]{4,15}$", ErrorMessage = "Only letters, numbers, and underscores are allowed.")]
        public string UserName { get; set; }
    }
}