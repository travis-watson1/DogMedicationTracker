using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DogMedicationTracker.Data;
using DogMedicationTracker.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DogMedicationTracker.Controllers
{
    public class DogsController : Controller
    {

        private readonly DogMedicationTrackerContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public DogsController(DogMedicationTrackerContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }


        //GET /dogs/create
        public IActionResult Create()
        {
            ViewBag.MedicationNames = new SelectList(context.Medications.OrderBy(x => x.Name), "Name", "Name");

            return View();
        }        
        
        
        //POST /dogs/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dog dog)
        {
            if (ModelState.IsValid)
            {
                string imageName = "noimage.png";


                if (dog.ImageUpload != null)
                {
                    var rand = new Random();
                    var randomNumber = rand.Next(1000);
                    string uploadsDir = Path.Combine(webHostEnvironment.WebRootPath, "media/uploads");
                    imageName = randomNumber + dog.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await dog.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                }

                dog.Image = imageName;


                context.Add(dog);
                await context.SaveChangesAsync();

                TempData["Success"] = "Your pet has been successfully created.";

                return RedirectToAction("Index", "Tasks");
            }

            TempData["Error"] = "There was an error adding your pet.";
            return View(dog);
        }
    }
    
}