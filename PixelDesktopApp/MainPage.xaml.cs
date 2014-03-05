using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PixelDesktopApp.Resources;
using PixelDesktopApp.Views;
using PixelDesktopApp.ViewModels;

namespace PixelDesktopApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            // DataContext = new MainViewModel();

            //BuildLocalizedApplicationBar();
        }

        private void Pin(int i)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("mushroom" + i));
            if (tile != null && tile.NavigationUri.ToString().Contains("mushroom" + i))
            {
                FlipTileDataManager.Update(i);
            }
            else
            {
                ShellTileData tileData = FlipTileDataManager.Create(i);
                ShellTile.Create(new Uri("/MainPage.xaml?DefaultTitle=mushroom" + i, UriKind.Relative), tileData, true);
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Pin(1);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Pin(2);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Pin(3);
        }
    }
}