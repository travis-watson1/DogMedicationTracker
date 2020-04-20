using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogMedicationTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace DogMedicationTracker.Data
{
    public class DogMedicationTrackerContext : DbContext
    {
        public DogMedicationTrackerContext(DbContextOptions<DogMedicationTrackerContext> options) :base(options)
        {
                
        }

        public DbSet<Dog> Dogs { get; set; }

    }
}
