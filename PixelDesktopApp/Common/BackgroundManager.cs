using PixelDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Common
{
    public class BackgroundManager
    {
         public IDictionary<BackgroundType, IBackground> BackgroundList { get; set; }
         public BackgroundManager()
        {
            BackgroundList = new Dictionary<BackgroundType, IBackground> 
            {
                { BackgroundType.Light, new BackgroundLight() },
                { BackgroundType.Dark, new BackgroundDark() },
               
            };
        }

         public string GetImageUrlList(BackgroundType type)
        {
            return BackgroundList[type].Get();
        }
    }
}
