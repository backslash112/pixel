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
        private ObservableCollection<string> _thumbnail;
        ItemRepository _deskRepository;
        public ItemListViewModelBase()
        {
            _thumbnail = LoadThumbnail();
            _deskRepository = ItemRepository.Instance;
        }

        protected virtual ObservableCollection<string> LoadThumbnail()
        {
            return null;
        }

        public ObservableCollection<string> Thumbnail
        {
            get { return _thumbnail; }
        }
    }
}
