using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogMedicationTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DogMedicationTracker.Data
{
    public class DogMedicationTrackerContext : IdentityDbContext<AppUser>
    {
        public DogMedicationTrackerContext(DbContextOptions<DogMedicationTrackerContext> options) :base(options)
        {
                
        }

        public DbSet<Dog> Dogs { get; set; }

    }
}
