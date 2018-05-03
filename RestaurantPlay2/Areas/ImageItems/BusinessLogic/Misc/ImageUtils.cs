using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.ImageItems.BusinessLogic.Misc
{
    public class ImageUtils
    {
        public string SaveImageFile(HttpPostedFileBase image)
        {
            try
            {
                if (image.ContentLength > 0)
                {
                    var _fileName = Path.GetFileName(image.FileName);
                    var _serverPath = $"/Content/Images/{_fileName}";
                    var _path = HttpContext.Current.Server.MapPath(_serverPath);
                    image.SaveAs(_path);
                    return _serverPath;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "Image save was unsuccessful!";
        }
    }
}