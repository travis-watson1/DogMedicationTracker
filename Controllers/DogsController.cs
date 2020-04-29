using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogMedicationTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult _Index()
        {
            return View();
        }


        //GET /dogs/create
        public IActionResult Create()
        {
            ViewBag.MedicationId = new SelectList(context.Medications.OrderBy(x => x.Name), "Id", "Name");

            return View();
        }
    }
}