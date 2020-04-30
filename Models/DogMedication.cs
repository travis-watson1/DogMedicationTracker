using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogMedicationTracker.Models
{
    public class DogMedication
    {

        public int DogId { get; set; }
        public Dog Dog { get; set; }



        public int MedicationId { get; set; }
        public Medication Medication { get; set; }

    }
}
