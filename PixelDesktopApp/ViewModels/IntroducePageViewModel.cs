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
    public class IntroducePageViewModel : ViewModelBase
    {
        ImageForLanguageServices services;
        public IntroducePageViewModel()
        {
            services = new ImageForLanguageServices();
            var result = services.GetIntroduceImages();

            _images = new ObservableCollection<IntroduceImage>();
            for (int i = 0; i < result.Count; i++)
            {
                _images.Add(new IntroduceImage { Id = i + 1, Url = result[i] });
            }

        }
        private ObservableCollection<IntroduceImage> _images;

        public ObservableCollection<IntroduceImage> Images
        {
            get { return _images; }
            set { _images = value; }
        }
    }
}
