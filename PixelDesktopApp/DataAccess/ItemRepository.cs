using PixelDesktopApp.Common;
using PixelDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace PixelDesktopApp.DataAccess
{
    public class ItemRepository
    {
        List<Item> _items;
        public BackgroundType Type { get; set; }

        private static ItemRepository _instance;
        public static ItemRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ItemRepository();
                }
                return _instance;
            }
        }
        private ItemRepository()
        {

        }
        public void Init()
        {
            _items = LoadItems(Type);
        }

        public List<Item> GetItems()
        {
            return new List<Item>(_items);
        }

        private static List<ImageModel> _images;
        static List<Item> LoadItems(BackgroundType type)
        {
            LoadImages(type);

            List<Item> result = new List<Item>();

            XDocument xml = XDocument.Load("Data/items.xml");
            foreach (var item in xml.Element("items").Elements("item"))
            {
                var tempDesk = new Item();
                tempDesk.Number = int.Parse((item.Attribute("number").Value));
                var images = _images.Where(i => i.number == tempDesk.Number);
                if (images.Any())
                {
                    tempDesk.Images = images.ToList();
                }
                tempDesk.Type = (ImagePartType)Enum.Parse(typeof(ImagePartType), item.Attribute("type").Value);

                result.Add(tempDesk);

            }
            return result;
        }

        private static void LoadImages(BackgroundType type)
        {
            switch (type)
            {
                case BackgroundType.Light:

                    _images = GetImagesXmlData("Data/lightImages.xml");
                    break;

                case BackgroundType.Dark:

                    _images = GetImagesXmlData("Data/darkImages.xml");
                    break;
            }
        }

        private static List<ImageModel> GetImagesXmlData(string file)
        {
            List<ImageModel> result = new List<ImageModel>();
            IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();

            XDocument xml = XDocument.Load(file);
            foreach (var item in xml.Element("images").Elements("image"))
            {
                var tempImage = new ImageModel();
                tempImage.id = int.Parse((item.Attribute("id").Value));
                tempImage.number = int.Parse((item.Attribute("number").Value));
                tempImage.url = item.Attribute("url").Value;

                result.Add(tempImage);
            }
            return result;
        }

        internal Item GetItemByNumber(int number)
        {
            return _items.First(i => i.Number == number);
        }
    }
}
