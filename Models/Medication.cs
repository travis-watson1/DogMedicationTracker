using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogMedicationTracker.Models
{
    public class Medication
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Interval { get; set; }

    }
}
