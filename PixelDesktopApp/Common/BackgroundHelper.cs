using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PixelDesktopApp.Common
{
    public class BackgroundHelper
    {
        public static BackgroundType GetBackgroundType()
        {
            if (((SolidColorBrush)App.Current.Resources["PhoneBackgroundBrush"]).Color == Colors.White)
            {
                return BackgroundType.Light;
            }
            else
            {
                return BackgroundType.Dark;
            }
        }
    }
}
