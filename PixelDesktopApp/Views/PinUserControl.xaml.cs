using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PixelDesktopApp.Common;
using System.Windows.Media;
using System.Diagnostics;
using PixelDesktopApp.Models;

namespace PixelDesktopApp.Views
{
    public partial class PinUserControl : UserControl
    {
        public PinUserControl()
        {
            InitializeComponent();


            ItemPage.PreviewHold += () =>
            {
                //if (root.Visibility == Visibility.Visible)
                    root.Visibility = Visibility.Collapsed;
            };

            ItemPage.PreviewUnhold += () =>
            {
                //if (!Pined)
                    root.Visibility = Visibility.Visible;
            };

            switch (BackgroundHelper.GetBackgroundType())
            {
                case BackgroundType.Light:
                    root.Background = new SolidColorBrush(Colors.Black);
                    root.Background.Opacity = 0.3;
                    break;

                case BackgroundType.Dark:
                    root.Background = new SolidColorBrush(Colors.White);
                    root.Background.Opacity = 0.3;
                    break;
            }

            //Loaded += (s, e) =>
            //{
            //    _pined = FlipTileDataManager.DeskContainsImage(Image);
            //};
        }


        public static event Action<ImageModel> Pin;
        public bool Pined { get; set; }
        public ImageModel Image
        {
            get { return (ImageModel)GetValue(ImageIdProperty); }
            set { SetValue(ImageIdProperty, value); }
        }
        public static readonly DependencyProperty ImageIdProperty =
            DependencyProperty.Register("Image", typeof(ImageModel), typeof(PinUserControl), null);
        private void PinButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Pin != null)
            {
                root.Visibility = Visibility.Collapsed;
                Pined = true;
                Pin(Image);
            }
        }
    }
}
