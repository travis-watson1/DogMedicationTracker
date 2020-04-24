using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogMedicationTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DogMedicationTracker.Controllers
{
    public class DogsController : Controller
    {

        private readonly DogMedicationTrackerContext context;

        public DogsController(DogMedicationTrackerContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}