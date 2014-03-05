using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PixelDesktopApp.Views
{
    public class FlipTileDataManager
    {
        static Uri GetImage(int part)
        {
            Debug.WriteLine(string.Format("/Images/mushroom{0}.png", part));
            return new Uri(string.Format("/Images/mushroom{0}.png", part), UriKind.Relative);
        }
        public static FlipTileData Create(int part)
        {
            return new FlipTileData()
            {
                Title = " ",
                // BackgroundImage = new Uri("", UriKind.Relative),
                WideBackgroundImage = GetImage(part)
            };
        }

        public static void Update(int part)
        {
            Debug.WriteLine("Update()");
            // create a newTileData.
            var newTileData = Create(part);
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("mushroom" + part));
            tile.Update(newTileData);
            MessageBox.Show("Update Part " + part + " Success!", "Alert", MessageBoxButton.OK);
        }

    }
}
