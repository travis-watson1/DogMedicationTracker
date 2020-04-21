using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DogMedicationTracker.Models
{
    public class UserEdit
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password),MinLength(2, ErrorMessage = "Must be at least 2 characters long.")]
        public string Password { get; set; }


        public UserEdit()
        {
            
        }

        public UserEdit(AppUser appUser)
        {
            Email = appUser.Email;
            Password = appUser.PasswordHash;
        }
    }
}
