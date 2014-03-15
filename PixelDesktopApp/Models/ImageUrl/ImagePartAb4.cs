using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Models
{
    public class ImagePartAb4 : IImagePart
    {
        //Images/part/black/51.png
        //Images/part/black/521.png
        //Images/part/black/522.png
        //Images/part/black/523.png
        //Images/part/black/524.png
        public List<string> Get(string url)
        {
            List<string> result = new List<string>()
            {
                string.Format("{0}/{1}", url, "51.png"),
                string.Format("{0}/{1}", url, "521.png"),
                string.Format("{0}/{1}", url, "522.png"),
                string.Format("{0}/{1}", url, "523.png"),
                string.Format("{0}/{1}", url, "524.png")
            };
            return result;
        }
    }
}
