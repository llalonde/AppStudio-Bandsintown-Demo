using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class MainViewModel : BindableBase
    {
       private ConcertsViewModel _concertsModel;
       private TwitterViewModel _twitterModel;
       private VideosViewModel _videosModel;
       private BlogViewModel _blogModel;
        private PrivacyViewModel _privacyModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModel()
        {
            _selectedItem = ConcertsModel;
            _privacyModel = new PrivacyViewModel();

        }
 
        public ConcertsViewModel ConcertsModel
        {
            get { return _concertsModel ?? (_concertsModel = new ConcertsViewModel()); }
        }
 
        public TwitterViewModel TwitterModel
        {
            get { return _twitterModel ?? (_twitterModel = new TwitterViewModel()); }
        }
 
        public VideosViewModel VideosModel
        {
            get { return _videosModel ?? (_videosModel = new VideosViewModel()); }
        }
 
        public BlogViewModel BlogModel
        {
            get { return _blogModel ?? (_blogModel = new BlogViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            ConcertsModel.ViewType = viewType;
            TwitterModel.ViewType = viewType;
            VideosModel.ViewType = viewType;
            BlogModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public Visibility AppBarVisibility
        {
            get
            {
                return SelectedItem == null ? AboutVisibility : SelectedItem.AppBarVisibility;
            }
        }

        public Visibility AboutVisibility
        {

         get { return Visibility.Visible; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("AppBarVisibility");
            OnPropertyChanged("AboutVisibility");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadDataAsync(bool forceRefresh = false)
        {
            var loadTasks = new Task[]
            { 
                ConcertsModel.LoadItemsAsync(forceRefresh),
                TwitterModel.LoadItemsAsync(forceRefresh),
                VideosModel.LoadItemsAsync(forceRefresh),
                BlogModel.LoadItemsAsync(forceRefresh),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await LoadDataAsync(true);
                });
            }
        }

        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand PrivacyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateTo(_privacyModel.Url);
                });
            }
        }
    }
}
