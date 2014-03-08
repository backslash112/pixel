using PixelDesktopApp.Common;
using PixelDesktopApp.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Models
{
    public class Item
    {
        private int _number;
        private List<ImageModel> _images;

        public List<ImageModel> Images
        {
            get { return _images; }
            set { _images = value; }
        }

        public string TypeString
        {
            get { return _type.ToString(); }
        }
        private ImagePartType _type;

        public ImagePartType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public Item()
        {

        }
        public Item(int number)
        {
            _number = number;

        }
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string Name
        {
            get
            {
                return GetNameByNumber();
            }
        }

        private string GetNameByNumber()
        {
            if (_number == 1)
            {
                return AppResources.DefaultImageName1;
            }
            else if (_number == 2)
            {
                return AppResources.DefaultImageName2;
            }
            else if (_number == 3)
            {
                return AppResources.DefaultImageName3;
            }
            else if (_number == 4)
            {
                return AppResources.DefaultImageName4;
            }
            else if (_number == 5)
            {
                return AppResources.DefaultImageName5;
            }
            else if (_number == 6)
            {
                return AppResources.DefaultImageName6;
            }
            else if (_number == 7)
            {
                return AppResources.DefaultImageName7;
            }
            else if (_number == 8)
            {
                return AppResources.DefaultImageName8;
            }
            return string.Empty;
        }


    }
}
