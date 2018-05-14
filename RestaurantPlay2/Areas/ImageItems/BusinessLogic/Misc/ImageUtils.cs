using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.ImageItems.BusinessLogic.Misc
{
    public class ImageUtils
    {
        public string SaveImageFile(string base64ImageString, string imageName)
        {
            
            try
            {
                var serverPath = $"/Content/Images/{imageName}";
                var path = HttpContext.Current.Server.MapPath(serverPath);

                if (ConvertBase64ToImage(base64ImageString, path))
                    return serverPath;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return string.Empty;
        }

        /// <summary>
        /// YOU CANNOT CLOSE A MEMORY STREAM BEFORE SAVING TO THE DISK
        /// </summary>
        /// <param name="base64ImageString"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool ConvertBase64ToImage(string base64ImageString, string filePath)
        {
            try
            {
                var cleanBase64String = RemoveHtml5FileReaderText(base64ImageString);
                byte[] bytes = Convert.FromBase64String(cleanBase64String);

                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    var image = Image.FromStream(ms);
                    image.Save(filePath);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string RemoveHtml5FileReaderText(string base64ImageString)
        {
            return base64ImageString.Remove(0, 23);
        }
    }
}