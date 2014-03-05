using PixelDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PixelDesktopApp.DataAccess
{
    public class ItemRepository
    {
        readonly List<Item> _items;

        public ItemRepository()
        {
            _items = LoadItems();
        }

        public List<Item> GetItems()
        {
            return new List<Item>(_items);
        }

        static List<Item> LoadItems()
        {
            List<Item> result = new List<Item>();
            IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();

            if (!fileStorage.FileExists("Items.xml"))
                return result;

            using (var isoFileStream = new IsolatedStorageFileStream("Items.xml", System.IO.FileMode.Open, fileStorage))
            {
                using (XmlReader reader = XmlReader.Create(isoFileStream))
                {
                    XDocument xml = XDocument.Load(reader);
                    foreach (var item in xml.Element("items").Elements("item"))
                    {
                        var tempDesk = new Item();
                        tempDesk.Id = int.Parse((item.Element("Id").Value));
                        tempDesk.Name = item.Element("Name").ToString();
                        tempDesk.ImageSmall = item.Element("ImageSmall").ToString();
                        tempDesk.ImagePart1 = item.Element("ImagePart1").ToString();
                        tempDesk.ImagePart2 = item.Element("ImagePart2").ToString();
                        tempDesk.ImagePart3 = item.Element("ImagePart3").ToString();

                        result.Add(tempDesk);
                    }
                }
            }
            return result;
        }
    }
}
