using System;

using Windows.UI.Xaml.Controls;

using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class AboutThisAppPage : Page
    {
        public AboutThisAppPage()
        {
            this.InitializeComponent();
            AboutModel = new AboutThisAppViewModel();
            CreditsModel = new CreditsViewModel();
            this.DataContext = this;
        }

        public AboutThisAppViewModel AboutModel { get; private set; }
        public CreditsViewModel CreditsModel { get; private set; }
    }
}
