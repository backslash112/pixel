using PixelDesktopApp.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PixelDesktopApp.Common
{
    public class ImageForLanguageServices
    {

        private CultureInfo language;
        public ImageForLanguageServices()
        {
            language = Thread.CurrentThread.CurrentCulture;
        }

        public List<string> GetIntroduceImages()
        {
            List<string> result = new List<string>();
            for (int i = 1; i < 4; i++)
            {
                result.Add(GetIntroduceImageById(i));
            }
            return result;
        }

        public string GetTipImage(ImageSize size)
        {
            var result = string.Format("/Images/Tile/{0}.{1}.png",
                size == ImageSize.Small ? "toSmall" : "toWide",
                AppResources.ResourceLanguage.Equals("zh-CN") ? "cn" : "en");

            Debug.WriteLine(result);
            return result;
        }
        private string GetIntroduceImageById(int id)
        {
            return string.Format("/Images/Introduce/{0}.{1}.png", id, AppResources.ResourceLanguage.Equals("zh-CN") ? "cn" : "en");
        }
    }
}
