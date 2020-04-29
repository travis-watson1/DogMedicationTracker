using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogMedicationTracker.Data;
using DogMedicationTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
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

        //GET /medications/edit/id
        public async Task<IActionResult> Edit(int id)
        {
            Medication medication = await context.Medications.FindAsync(id);

            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }        
        
        
        //POST /medications/edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Medication medication)
        {

            if (ModelState.IsValid)
            {
                var checkForDuplicate = await context.Medications.Where(x => x.Id != id)
                    .FirstOrDefaultAsync(x => x.Name == medication.Name);

                if (checkForDuplicate != null)
                {
                    ModelState.AddModelError("", "The medication already exists.");
                    return View(medication);
                }

                context.Update(medication);
                await context.SaveChangesAsync();

                TempData["Success"] = "The medication has been edited.";

                return RedirectToAction("Index");
            }

            return View(medication);
        }

        //GET /medications/delete/id
        public async Task<IActionResult> Delete(int id)
        {
            Medication medication = await context.Medications.FindAsync(id);

            if (medication == null)
            {
                TempData["Error"] = "The category does not exist.";
            }
            else
            {
                context.Medications.Remove(medication);
                await context.SaveChangesAsync();

                TempData["Success"] = "The medication has been deleted.";
            }

            return RedirectToAction("Index");
        }
    }
}