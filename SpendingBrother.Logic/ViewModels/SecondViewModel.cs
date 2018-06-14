namespace SpendingBrother.Logic.ViewModels
{
    using GalaSoft.MvvmLight;
    using SpendingBrother.Logic.Services.Interfaces;
    using SpendingBrother.Logic.ViewModels.Interfaces;
    
    public class SecondViewModel : ViewModelBase, ISecondViewModel
    {
        private IFrameNavigationService NavigationService { get; }

        /// <summary>
        /// Initializes a new instance of the SecondViewModel class.
        /// </summary>
        public SecondViewModel(IFrameNavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }
    }
}