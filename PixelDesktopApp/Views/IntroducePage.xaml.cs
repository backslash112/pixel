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

namespace PixelDesktopApp.Views
{
    public partial class IntroducePage : PhoneApplicationPage
    {
        public IntroducePage()
        {
            InitializeComponent();
            this.DataContext = new IntroducePageViewModel();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}