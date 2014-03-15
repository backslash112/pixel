using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Models
{
    public interface IImagePart
    {
        List<string> Get(string url);
    }
}
