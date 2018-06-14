namespace SpendingBrother.Logic.ViewModels
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using SpendingBrother.Logic.Services.Interfaces;
    using SpendingBrother.Logic.ViewModels.Interfaces;

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private IFrameNavigationService NavigationService { get; }

        public RelayCommand NavigatoToFirstCommand { get; }

        public RelayCommand NavigatoToSecondCommand { get; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IFrameNavigationService navigationService)
        {
            this.NavigationService = navigationService;
            this.NavigatoToFirstCommand = new RelayCommand(this.NavigateToFirst);
            this.NavigatoToSecondCommand = new RelayCommand(this.NavigateToSecond);
        }

        public void NavigateToFirst()
        {
            this.NavigationService.NavigateTo("FirstPage");
        }

        public void NavigateToSecond()
        {
            this.NavigationService.NavigateTo("SecondPage");
        }
    }
}