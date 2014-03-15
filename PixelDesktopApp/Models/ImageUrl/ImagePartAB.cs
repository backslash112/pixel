using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Models
{
    public class ImagePartAB : IImagePart
    {
        //Images/part/black/71.png
        public List<string> Get(string url)
        {
            List<string> result = new List<string>()
            {
                string.Format("{0}/{1}", url, "71.png"),
                string.Format("{0}/{1}", url, "72.png")
            };
            return result;
        }
    }
}
