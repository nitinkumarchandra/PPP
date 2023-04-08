using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using NitinPortal.DataConnection;
using NitinPortal.Models;
using NuGet.Packaging.Signing;
using System.Drawing;

namespace NitinPortal.Controllers
{
    public class EmployeeController : Controller
    {
        NitinPortalContext Db = new NitinPortalContext();
        public IActionResult Index()
        {
            var data = Db.Employees1.ToList();
            return View(data);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee1 s, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Check the file extension to make sure it's a valid image type.
                string filename = file.FileName;
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("file", "Invalid image type. Please upload a JPEG, PNG, or GIF.");
                    return View();
                }

                // Check the file size to make sure it's not too large.
                if (file.Length > (10 * 1024 * 1024)) // 10 MB
                {
                    ModelState.AddModelError("file", "The file size cannot exceed 10 MB.");
                    return View();
                }

                // Save the file to disk.
                //var fileName = Guid.NewGuid().ToString() + extension;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }

                Employee1 obj = new Employee1();

                obj.Name = s.Name;
                obj.Email = s.Email;
                obj.NewImagePath = filename;

                Db.Employees1.Add(obj);
                Db.SaveChanges();

                // TODO: Save the file path to your database or use it in some way.

                return RedirectToAction("Index");
            }

            // Handle the case where no file is uploaded.
            ModelState.AddModelError("file", "Please select a file to upload.");

            return View();
        }
    }
}
