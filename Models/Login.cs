using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogMedicationTracker.Models
{
    public class Login
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(2, ErrorMessage = "Must be at least 2 characters long.")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

    }
}
