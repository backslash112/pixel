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
using System.Diagnostics;
using PixelDesktopApp.Models;

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

            PinUserControl.Pin += PinImage;
        }

        private void PinImage(ImageModel image)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(image.url));
            if (tile != null && tile.NavigationUri.ToString().Contains(image.id.ToString()))
            {
                MessageBox.Show("successfully update.");
            }
            else
            {
                ShellTileData tileData = FlipTileDataManager.Create(image);
                ShellTile.Create(new Uri("/MainPage.xaml?imageId=" + image.id, UriKind.Relative), tileData, true);
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

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            PinUserControl.Pin -= PinImage;
        }

        public static event Action PreviewHold;
        public static event Action PreviewUnhold;


        private void gridPreview_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            if (PreviewHold != null)
            {
                PreviewHold();
            }
        }

        private void gridPreview_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            if (PreviewUnhold != null)
            {
                PreviewUnhold();
            }
        }
    }
}