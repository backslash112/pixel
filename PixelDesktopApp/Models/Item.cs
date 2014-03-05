using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Models
{
    public class Item
    {
        private int _id;
        private string _name;
        private string _imageSmall;
        private string _imagePart1;
        private string _imagePart2;
        private string _imagePart3;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ImageSmall
        {
            get { return _imageSmall; }
            set { _imageSmall = value; }
        }

        public string ImagePart1
        {
            get { return _imagePart1; }
            set { _imagePart1 = value; }
        }

        public string ImagePart2
        {
            get { return _imagePart2; }
            set { _imagePart2 = value; }
        }

        public string ImagePart3
        {
            get { return _imagePart3; }
            set { _imagePart3 = value; }
        }
    }
}
