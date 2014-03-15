using PixelDesktopApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Models
{
    public class ImageModel
    {
        public int id { get; set; }
        public int number { get; set; }
        public string url { get; set; }
        public ImageSize Size { get; set; }
    }
}
