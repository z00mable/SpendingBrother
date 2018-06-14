namespace SpendingBrother.Logic.ViewModels
{
    using GalaSoft.MvvmLight;
    using SpendingBrother.Logic.Services.Interfaces;
    using SpendingBrother.Logic.ViewModels.Interfaces;

    public class FirstViewModel : ViewModelBase, IFirstViewModel
    {
        private IFrameNavigationService NavigationService { get; }

        /// <summary>
        /// Initializes a new instance of the FirstViewModel class.
        /// </summary>
        public FirstViewModel(IFrameNavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }
    }
}