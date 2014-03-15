using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Common
{
    public class ImageForBackgroundServices
    {
        public List<List<string>> UrlList { get; set; }
        public List<string> ThumbnailList { get; set; }

        public BackgroundType Type { get; set; }
        private string BackgroundString
        {
            get { return Type == BackgroundType.Dark ? "black" : "white"; }
        }
        public ImageForBackgroundServices()
        {
            Type = BackgroundHelper.GetBackgroundType();
            // UNDONE:
            //for (int number = 1; number < 8; number++)
            //{
            //    BackgroundManager backgroundManagr = new BackgroundManager();
            //    var backgroundUrl = backgroundManagr.GetImageUrlList(Type);

            //    ImagePartManager imagePartManager = new ImagePartManager();
            //    var imagePartUrlList = imagePartManager.GetImageUrlList(ImagePartType.AB, backgroundUrl);
            //}

            // Load Thumbnail
            ThumbnailList = new List<string>();
            for (int i = 1; i < (Type == BackgroundType.Dark ? 9 : 10); i++)
            {
                ThumbnailList.Add(string.Format("/Images/thumbnail/{0}/{1}.png", (Type == BackgroundType.Dark ? "Dark" : "Light"), i));
            }
        }

    }
}
