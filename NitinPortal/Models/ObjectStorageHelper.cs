using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace NitinPortal.Models
{
    public static class ObjectStorageHelper
    {
        public static bool PutObject(string filePath, IFormFile file)
        {
            bool imageUpload = false;

            string basePath = "C://ObjectStorage/";
            string fullPath = Path.Combine(basePath, filePath);

            string folder = Path.GetDirectoryName(fullPath);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);


            if (!File.Exists(filePath))
            {
                using (FileStream outputFileStream = new FileStream(fullPath, FileMode.Create))
                {
                    var fileBytes = ConvertToBytes(file);
                    outputFileStream.Write(fileBytes, 0, fileBytes.Length);
                    imageUpload = true;
                }
            }
            return imageUpload;
        }
        private static Byte[] ConvertToBytes(IFormFile file)
        {
            byte[] bytes = null;

            BinaryReader reader = new BinaryReader(file.OpenReadStream());
            bytes = reader.ReadBytes((int)file.Length);

            return bytes;
        }
    }
}
