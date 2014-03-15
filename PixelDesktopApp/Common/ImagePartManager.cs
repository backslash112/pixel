using PixelDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Common
{
    public class ImagePartManager
    {
        public IDictionary<ImagePartType, IImagePart> ImageParts { get; set; }
        public ImagePartManager()
        {
            ImageParts = new Dictionary<ImagePartType, IImagePart> 
            {
                { ImagePartType.AB, new ImagePartAB() },
                { ImagePartType.Ab4, new ImagePartAb4() },
                { ImagePartType.ABC, new ImagePartABC() },
                { ImagePartType.ABc4, new ImagePartABc4() },
                { ImagePartType.ABCd4, new ImagePartABCd4() },
                { ImagePartType.Seven, new ImagePartSeven() }
            };
        }

        public List<string> GetImageUrlList(ImagePartType type,string url)
        {
            return ImageParts[type].Get(url);
        }
    }
}
