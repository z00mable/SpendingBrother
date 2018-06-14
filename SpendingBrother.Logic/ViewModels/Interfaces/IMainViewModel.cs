namespace SpendingBrother.Logic.ViewModels.Interfaces
{
    using GalaSoft.MvvmLight.Command;

    public interface IMainViewModel
    {
        RelayCommand NavigatoToFirstCommand { get; }
        RelayCommand NavigatoToSecondCommand { get; }
    }
}