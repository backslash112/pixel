using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PixelDesktopApp.ViewModels;
using PixelDesktopApp.Common;
using System.Windows.Media;

namespace PixelDesktopApp.Views
{
    public partial class ItemPage : PhoneApplicationPage
    {
        public ItemPage()
        {
            InitializeComponent();


            if (BackgroundHelper.GetBackgroundType() == BackgroundType.Dark)
            {
                LayoutRoot.Background = new SolidColorBrush(Colors.Black);
                title.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                LayoutRoot.Background = new SolidColorBrush(Colors.White);
                title.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string number;
            if (NavigationContext.QueryString.TryGetValue("number", out number))
            {
                DataContext = new ItemViewModel(int.Parse(number));
            }
        }
    }
}