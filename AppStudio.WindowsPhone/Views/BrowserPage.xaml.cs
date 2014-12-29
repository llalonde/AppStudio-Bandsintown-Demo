using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace AppStudio.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrowserPage : Page
    {
        private NavigationHelper _navigationHelper;

        public string NavigationUrl { get; protected set; }
        public BrowserPage()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);


            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                this.NavigationUrl = e.Parameter.ToString();
                webView.Navigate(new Uri(this.NavigationUrl));
            }

            DataContext = this;
        }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        bool isNavigating = false;

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
        }

        
    }
}
