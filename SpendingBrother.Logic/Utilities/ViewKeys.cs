using System;

namespace SpendingBrother.Logic.Utilities
{
    public static class ViewKeys
    {
        public const string FirstPageKey = "FirstPage";
        public const string SecondPageKey = "SecondPage";

        public static readonly Uri FirstPageUri = new Uri("../Views/FirstPage.xaml", UriKind.Relative);
        public static readonly Uri SecondPageUri = new Uri("../Views/SecondPage.xaml", UriKind.Relative);
    }
}
