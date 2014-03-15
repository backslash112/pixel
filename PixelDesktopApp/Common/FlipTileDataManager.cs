using Microsoft.Phone.Shell;
using PixelDesktopApp.Models;
using PixelDesktopApp.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Common
{
    public class FlipTileDataManager
    {
        public FlipTileDataManager()
        {
            ImageForLanguageServices services = new ImageForLanguageServices();
            _resizeWidthImageUri = new Uri(services.GetTipImage(ImageSize.Width), UriKind.Relative);
            _resizeSmallImageUri = new Uri(services.GetTipImage(ImageSize.Small), UriKind.Relative);
        }
        Uri EmptyUri { get { return new Uri("", UriKind.Relative); } }
        Uri _resizeWidthImageUri;
        Uri _resizeSmallImageUri;
        public FlipTileData Create(ImageModel image)
        {
            Debug.WriteLine(image.id);
            return new FlipTileData()
            {
                Title = "",
                WideBackgroundImage = (image.Size == ImageSize.Width ? new Uri(image.url, UriKind.Relative) : EmptyUri),
                BackgroundImage = (image.Size == ImageSize.Normal ? new Uri(image.url, UriKind.Relative) : (image.Size == ImageSize.Width ? _resizeWidthImageUri : _resizeSmallImageUri)),
                SmallBackgroundImage = (image.Size == ImageSize.Small ? new Uri(image.url, UriKind.Relative) : EmptyUri),
            };
        }

        public void Update(ImageModel image)
        {
            Debug.WriteLine(image.id);
            // create a newTileData.
            var newTileData = Create(image);
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(image.url));
            tile.Update(newTileData);
        }

        public bool DeskContainsImage(ImageModel image)
        {
            if (image == null)
            {
                return false;
            }
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(image.url));
            return (tile != null && tile.NavigationUri.ToString().Contains(image.url.ToString()));
        }
    }
}
