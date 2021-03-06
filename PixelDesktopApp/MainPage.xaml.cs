﻿using System;
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
using System.Threading;
using PixelDesktopApp.DataAccess;
using PixelDesktopApp.Common;

namespace PixelDesktopApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            this.PivotDefault.DataContext = new DefaultItemListViewModel();

            Loaded += (s, e) =>
            {
                ItemRepository repository = ItemRepository.Instance;
                repository.Type = BackgroundHelper.GetBackgroundType();
                repository.Init();
            };
            
            MarketplaceReviewServices marketplaceReviewServices = new MarketplaceReviewServices(this);
            marketplaceReviewServices.RateDays = 5;
            marketplaceReviewServices.Run();
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
            NavigationService.Navigate(new Uri("/Views/ItemPage.xaml?number=" + number, UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
            //首次进入App，跳转到引导页。
            if ((AppCommon.Instance.Launched == null) || !(bool)AppCommon.Instance.Launched)
            {
                AppCommon.Instance.Launched = true;
                NavigationService.Navigate(new Uri("/Views/IntroducePage.xaml", UriKind.Relative));

            }
            else
            {
                base.OnNavigatedTo(e);
            }
        }
    }
}