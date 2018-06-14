namespace SpendingBrother.Logic.Services.Interfaces
{
    using GalaSoft.MvvmLight.Views;

    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}