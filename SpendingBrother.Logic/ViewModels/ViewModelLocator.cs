namespace SpendingBrother.Logic.ViewModels
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Ioc;
    using SpendingBrother.Logic.Services;
    using SpendingBrother.Logic.Services.Interfaces;
    using SpendingBrother.Logic.Utilities;
    using SpendingBrother.Logic.ViewModels.Interfaces;

    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SetupNavigation();

            if (ViewModelBase.IsInDesignModeStatic)
            {
                //// Create design time view services and models
                //SimpleIoc.Default.Register<IFirstViewModel, DesignDataService>();
            }
            else
            {
                // Create run time view services and models
            }

            SimpleIoc.Default.Register<IMainViewModel, MainViewModel>();
            SimpleIoc.Default.Register<IFirstViewModel, FirstViewModel>();
            SimpleIoc.Default.Register<ISecondViewModel, SecondViewModel>();
        }

        public IMainViewModel MainViewModel => ServiceLocator.Current.GetInstance<IMainViewModel>();

        public IFirstViewModel FirstViewModel => ServiceLocator.Current.GetInstance<IFirstViewModel>();

        public ISecondViewModel SecondViewModel => ServiceLocator.Current.GetInstance<ISecondViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure(ViewKeys.FirstPageKey, ViewKeys.FirstPageUri);
            navigationService.Configure(ViewKeys.SecondPageKey, ViewKeys.SecondPageUri);

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }
    }
}