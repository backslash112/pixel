using PixelDesktopApp.DataAccess;
using PixelDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.ViewModels
{
    public class ItemListViewModelBase : ViewModelBase
    {
        private ObservableCollection<Item> _items;
        ItemRepository _deskRepository;
        public ItemListViewModelBase()
        {
            _items = LoadItems();
            _deskRepository = new ItemRepository();
        }

        protected virtual ObservableCollection<Item> LoadItems()
        {
            return null;
        }

        public ObservableCollection<Item> Items
        {
            get { return _items; }
        }
    }
}
