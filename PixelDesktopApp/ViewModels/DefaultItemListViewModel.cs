using PixelDesktopApp.Common;
using PixelDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.ViewModels
{
    public class DefaultItemListViewModel : ItemListViewModelBase
    {
        protected override ObservableCollection<string> LoadThumbnail()
        {
            ImageForBackgroundServices services = new ImageForBackgroundServices();
            return new ObservableCollection<string>(services.ThumbnailList);
        }
    }
}
