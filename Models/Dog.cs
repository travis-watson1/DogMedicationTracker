﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogMedicationTracker.Models
{
    public class Dog
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string Sex { get; set; }

        public string Image { get; set; }

    }
}
