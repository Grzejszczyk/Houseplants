using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Houseplants.Models;
using Houseplants.Views.Edit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;

namespace Houseplants.Controllers
{
    public class EditController : Controller
    {
        private IHouseplantRepository repoHouseplants;
        public EditController(IHouseplantRepository repo)
        {
            repoHouseplants = repo;
        }
        public IActionResult Index()
        {
            return View(repoHouseplants.Houseplants);
        }

        public IActionResult Edit(int HouseplantId)
        {
            byte[] imgData = repoHouseplants.Houseplants.FirstOrDefault(h => h.HouseplantId == HouseplantId).Thumbnail;
            ViewBag.ImgData = File(imgData, "image/*");
            return View(repoHouseplants.Houseplants.FirstOrDefault(h => h.HouseplantId == HouseplantId));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Houseplant houseplant)
        {

            using (var memoryStream = new MemoryStream())
            {
                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    await houseplant.ImageFile.CopyToAsync(memoryStream);
                    houseplant.Thumbnail = memoryStream.ToArray();
                }
            }

            if (ModelState.IsValid)
            {
                repoHouseplants.SaveHouseplant(houseplant);
                return RedirectToAction("Index");
            }
            else
            {
                return View(houseplant);
            }
        }
        [HttpPost]
        public async Task<IActionResult> OnPostUploadAsync(IFormFile file)
        {
            if (file.Length > 0)
            {
                string filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
