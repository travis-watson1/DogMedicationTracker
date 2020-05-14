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
        public async Task<IActionResult> Index()
        {
            return View(await context.Dogs.ToListAsync());
        }


        //GET /dogs/create
        public IActionResult Create()
        {
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
                    //var rand = new Random();
                    //var randomNumber = rand.Next(1000);
                    string uploadsDir = Path.Combine(webHostEnvironment.WebRootPath, "media/uploads");
                    imageName = dog.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await dog.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                }

                dog.Image = imageName;


                context.Add(dog);
                await context.SaveChangesAsync();

                TempData["Success"] = "Your pet has been successfully created.";

                return RedirectToAction("Index", "Dogs");
            }

            TempData["Error"] = "There was an error adding your pet.";
            return View(dog);
        }

        //GET /dogs/edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Dog dog = await context.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }        
        
        //POST /dogs/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Dog dog)
        {
            if (ModelState.IsValid)
            {
                if (dog.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(webHostEnvironment.WebRootPath, "media/uploads");

                    if (!string.Equals(dog.Image, "noimage.png") && dog.Image != null)
                    {
                        string oldImagePath = Path.Combine(uploadsDir, dog.Image);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                    }

                    string imageName =dog.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await dog.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    dog.Image = imageName;
                }

                context.Update(dog);
                await context.SaveChangesAsync();

                TempData["Success"] = "Your pet has been edited.";

                return RedirectToAction("Index");
            }

            return View(dog);
        }

        //GET /dogs/details/5
        public async Task<IActionResult> Details(int id)
        {
            Dog dog = await context.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        //GET /dogs/delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Dog dog = await context.Dogs.FindAsync(id);

            if (dog == null)
            {
                TempData["Error"] = "The dog does not exist.";
            }
            else
            {
                if (!string.Equals(dog.Image, "noimage.png"))
                {
                    string uploadsDir = Path.Combine(webHostEnvironment.WebRootPath, "media/uploads");
                    string oldImagePath = Path.Combine(uploadsDir, dog.Image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                context.Dogs.Remove(dog);
                await context.SaveChangesAsync();

                TempData["Success"] = "Your pet has been deleted.";
            }

            return RedirectToAction("Index");
        }
    }
    
}