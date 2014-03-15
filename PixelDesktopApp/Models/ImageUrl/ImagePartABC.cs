using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Models
{
    public class ImagePartABC : IImagePart
    {
        public List<string> Get(string url)
        {
            throw new NotImplementedException();
        }
    }
}
