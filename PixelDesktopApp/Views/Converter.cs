using PixelDesktopApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PixelDesktopApp.Views
{
    public class TypeToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var type = (ImagePartType)Enum.Parse(typeof(ImagePartType), value.ToString());
            switch (type)
            {
                case ImagePartType.AB:

                    break;
                case ImagePartType.ABC:
                    break;
                case ImagePartType.Ab4:
                    break;
                case ImagePartType.ABc4:
                    break;
                case ImagePartType.ABCd4:
                    break;
                case ImagePartType.Seven:
                    break;
                default:
                    break;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

}
