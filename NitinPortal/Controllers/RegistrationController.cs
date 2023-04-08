using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NitinPortal.DataConnection;
using NitinPortal.Models;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Collections;

namespace NitinPortal.Controllers
{
    public class RegistrationController : Controller
    {
        bool isImageValid = true;
        NitinPortalContext Db = new NitinPortalContext();

        [HttpGet]
        public IActionResult Index()
        {
            List<Country> countryData = Db.Countries.OrderBy(model => model.CountryName).ToList();
            ViewBag.countryList = new SelectList(countryData, "CountryId", "CountryName");
            return View();
        }
        [HttpPost]
        public IActionResult Index(Employee e, string LastName, Country country)
        {
            Employee obj = new Employee();

            obj.Name = e.Name + " " + LastName;
            obj.Email = e.Email;
            obj.CompanyName = e.CompanyName;
            obj.Country = country.CountryName;


            return View();
        }

        public JsonResult GetState(int CountryId)
        {


            List<State> serverdata = Db.States.Where(model => model.CountryId == CountryId).ToList();
            return Json(serverdata, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        // File Save in Database and Filepath

        [HttpPost]
        public JsonResult BulkSaveUpload()
        {
            int imageId = 0;
            var file = Request.Form.Files[0];
            var filename = file.FileName;
            var extension = Path.GetExtension(filename);
            var fileSize = file.Length;
            string[] validImageExtension = { ".png", ".jpg", "jpeg" };

            if (!validImageExtension.Contains(extension))
                isImageValid = false;

            string filePath = "Image/" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss-ff") + "_" + filename;

            bool isImageUpload = ObjectStorageHelper.PutObject(filePath, file);

            if (isImageUpload)
            {
                Image imgObj = new Image()
                {
                    Name = filename,
                    Extension = extension,
                    FileSize = fileSize.ToString(),
                    FilePath = filePath,
                    FileType = "Image"
                };
                Db.Images.Add(imgObj);
                Db.SaveChanges();

                imageId = imgObj.ImageId;
            }
            return Json(imageId);
        }
    }
}
