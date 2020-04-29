using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogMedicationTracker.Data;
using DogMedicationTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DogMedicationTracker.Controllers
{
    public class MedicationsController : Controller
    {

        private readonly DogMedicationTrackerContext context;

        public MedicationsController(DogMedicationTrackerContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await context.Medications.OrderBy(x => x.Name).ToListAsync());

        }

        //GET /medications/create
        public IActionResult Create()
        {
            return View();
        }        
        
        //POST /medications/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medication medication)
        {
            if (ModelState.IsValid)
            {
                context.Add(medication);
                await context.SaveChangesAsync();

                TempData["Success"] = "The medication has been added.";

                return RedirectToAction("Index");
            }

            return View(medication);
        }
    }
}