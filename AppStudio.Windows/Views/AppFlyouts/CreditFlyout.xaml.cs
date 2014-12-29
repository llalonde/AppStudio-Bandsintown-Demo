using AppStudio.ViewModels;
using Windows.UI.Xaml.Controls;

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace AppStudio.Views
{
    public sealed partial class CreditFlyout : SettingsFlyout
    {
        
        public CreditFlyout()
        {
            this.InitializeComponent();
            CreditsViewModel = new CreditsViewModel();
            this.DataContext = this;
        }

        public CreditsViewModel CreditsViewModel { get; private set; }
    }
}
