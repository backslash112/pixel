using PixelDesktopApp.DataAccess;
using PixelDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private ItemViewModel()
        {

        }

        private Item _item;

        public Item Item
        {
            get { return _item; }
        }
        public ItemViewModel(int number)
        {
            _item = GetItemByNumber(number);
            NotifyPropertyChanged(() => Item);
        }

        private Item GetItemByNumber(int number)
        {
            Item item = new Item(number);
            ItemRepository itemRepository =  ItemRepository.Instance;
            item = itemRepository.GetItemByNumber(number);
            return item;
        }

    }
}
