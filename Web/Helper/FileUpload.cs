using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Helper
{
    public class FileUpload
    {
        public string Extension(IFormFile picture)
        {
            return picture == null || picture.Length <= 0 ? null : Path.GetExtension(picture.FileName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Dictionary<string, string>> DocumentFolder(IFormFile file)
        {


            var extension = Extension(file);

            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files\", fileName);

            //Creating picture
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }


            return new Dictionary<string, string>() { { fileName, extension } };
        }
    }
}
