using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NitinPortal.DataConnection;
using NitinPortal.Models;

namespace NitinPortal.Controllers
{
    public class DemoController : Controller
    {
        bool isImageValid = true;
        NitinPortalContext Db = new NitinPortalContext();
        public ActionResult Index()
        {
            return View();
        }


        // BY NITIN

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
                Images imgObj = new Images()

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
