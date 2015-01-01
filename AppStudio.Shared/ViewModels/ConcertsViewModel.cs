using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;
using AppStudio.Data.DataSchemas;
using Windows.System;

namespace AppStudio.ViewModels
{
    public class ConcertsViewModel : ViewModelBase<ConcertSchema>
    {
        private RelayCommandEx<ConcertSchema> itemClickCommand;
        public RelayCommandEx<ConcertSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<ConcertSchema>(
                        (item) =>
                        {
                            if (item.ticket_status.ToLower().Equals("available"))
                            {
                                LaunchArtistFanPage(new Uri(item.url));
                            }
                        });
                }

                return itemClickCommand;
            }
        }

        private async void LaunchArtistFanPage(Uri fanPageUri)
        {
            await Launcher.LaunchUriAsync(fanPageUri);
        }

        override protected DataSourceBase<ConcertSchema> CreateDataSource()
        {
            return new ConcertsDataSource(); 
        }


        override public Visibility GoToSourceVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected void GoToSource()
        {
            base.GoToSource("{FeedUrl}");
        }

        override public Visibility RefreshVisibility
        {
            get { return ViewType == ViewTypes.List ? Visibility.Visible : Visibility.Collapsed; }
        }

        public RelayCommandEx<Slider> IncreaseSlider
        {
            get
            {
                return new RelayCommandEx<Slider>(s => s.Value++);
            }
        }

        public RelayCommandEx<Slider> DecreaseSlider
        {
            get
            {
                return new RelayCommandEx<Slider>(s => s.Value--);
            }
        }

        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("ConcertsList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("ConcertsDetail");
        }
    }
}
