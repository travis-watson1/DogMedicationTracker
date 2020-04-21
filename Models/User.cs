﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DogMedicationTracker.Models
{
    public class User
    {
        [Required, MinLength(2, ErrorMessage = "Minimum length is 2."), Display(Name = "Username")]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password),Required, MinLength(2, ErrorMessage = "Must be at least 2 characters long.")]
        public string Password { get; set; }


        public User()
        {
            
        }

        public User(AppUser appUser)
        {
            UserName = appUser.UserName;
            Email = appUser.Email;
            Password = appUser.PasswordHash;
        }
    }
}
