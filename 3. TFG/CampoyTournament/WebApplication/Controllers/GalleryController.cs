using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Gallery;

namespace WebApplication.Controllers
{

    public class GalleryController : Controller
    {
        /// <summary>
        /// This method will return the list of the picture on the App folder
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ActionResult Index(string message)
        {
            if (message != null)
            {
                if (message.CompareTo(string.Empty) != 0)
                {
                    ModelState.AddModelError("ImageError", message);
                }
                else
                {
                    if (ModelState.ContainsKey("ImageError"))
                        ModelState["ImageError"].Errors.Clear();
                }
            }
            var uploadedFiles = new List<ImageViewModel>();
            
            string path = HttpContext.Server.MapPath("~/Content/UploadedFiles/");
            var files = Directory.GetFiles(path);         

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var uploadedFile = new ImageViewModel() { Name = Path.GetFileName(file)};
                uploadedFile.Size = fileInfo.Length;

                uploadedFile.Path = ("/Content/UploadedFiles/") + Path.GetFileName(file);
                uploadedFiles.Add(uploadedFile);
            }

            return View(uploadedFiles);
        }

        /// <summary>
        /// This method will insert the pictures into the App folder after validation
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Upload()
        {
            string modelError = string.Empty;
            if (Request.Files.Count == 0)
            {
                modelError = "No ha seleccionado ningún archivo";
                return RedirectToAction("Index", new { message = modelError });
            }
            foreach (string file in Request.Files)
            {
                var postedFile = Request.Files[file];
                if (((postedFile.ContentType != "image/jpeg") && (postedFile.ContentType != "image/gif")
                     && (postedFile.ContentType != "image/pjpeg") && (postedFile.ContentType != "image/png")) || (postedFile.InputStream.Length > 999999))
                {
                    modelError = "Alguno de los archivos no tiene el formato correcto o supera el tamaño permitido";
                    return RedirectToAction("Index", new {  message = modelError});
                }                
            }

            foreach (string file in Request.Files)
            {                

                //Convert to bitmap
                Image image = System.Drawing.Image.FromStream(Request.Files[file].InputStream);
                Bitmap bmp = new Bitmap(image);
               
                var date = System.DateTime.Now;
                var path = Server.MapPath("~/Content/UploadedFiles/");
                var fileName = date.Ticks + "_" + Path.GetFileName(Request.Files[file].FileName);

                //Resize and save image
                Save(bmp, 190, 190, path, fileName);                            
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This method will resize, convert and save an image.
        /// </summary>        
        public void Save(Bitmap image, int maxWidth, int maxHeight, string filePath, string fileName)
        {
            // Get the image's original width and height
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // To preserve the aspect ratio
            float ratioX = (float)maxWidth / (float)originalWidth;
            float ratioY = (float)maxHeight / (float)originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            // New width and height based on aspect ratio
            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            // Convert other formats (including CMYK) to RGB.
            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            // Draws the image in the specified size with quality mode set to HighQuality
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            // Save the new Image
            newImage.Save(filePath + fileName + ".jpg", ImageFormat.Jpeg);
            image.Dispose();
            newImage.Dispose();
        }
    }
}
