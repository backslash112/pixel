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
using System.Diagnostics;

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
            this.PivotDefault.DataContext = new DefaultItemListViewModel();
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

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show(AppResources.ExitConfirmMsg, AppResources.ExitText, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                this.ClearBackEntries();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void ClearBackEntries()
        {
            while (NavigationService.BackStack != null & NavigationService.BackStack.Count() > 0)
            {
                NavigationService.RemoveBackEntry();
            }
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // /Images/thumbnail/Dark/1.png
            var url = (string)((Image)sender).DataContext;
            var result = url.Split(new char[] { '/' });
            var number = result[result.Length - 1].Split(new char[] { '.' })[0];
            // Debug.WriteLine(id);
        }
    }
}