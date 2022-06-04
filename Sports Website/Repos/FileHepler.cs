using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public static class FileHepler
    {
        public static  string SaveFile(IFormFile formFile , string folderName)
        {
            string PhotosPath = folderName + "/wwwroot/Files/images/";

            string photoName = Guid.NewGuid() + Path.GetFileName(formFile.FileName);

            string FinalPhotoPath = Path.Combine(PhotosPath, photoName);
            //save photo to root 
            using (var stream = new FileStream(FinalPhotoPath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }

            return photoName;
        }
    }
}
