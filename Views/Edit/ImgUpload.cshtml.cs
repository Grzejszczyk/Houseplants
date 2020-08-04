using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Houseplants.Views.Edit
{
    public class ImgUploadModel : PageModel
    {
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
            return RedirectToPage("index");
        }
        // Process uploaded files
        // Don't rely on or trust the FileName property without validation.
        public void OnGet()
        {
        }
        [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }
    }
    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}