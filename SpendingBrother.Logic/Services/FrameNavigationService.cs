
namespace SpendingBrother.Logic.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using SpendingBrother.Logic.Services.Interfaces;

    public class FrameNavigationService : IFrameNavigationService, INotifyPropertyChanged
    {
        #region Fields

        private readonly Dictionary<string, Uri> pagesByKey;
        private readonly List<string> historic;
        private string currentPageKey;

        #endregion

        #region Properties                                              

        public string CurrentPageKey
        {
            get => this.currentPageKey;

            private set
            {
                if (this.currentPageKey == value)
                {
                    return;
                }

                this.currentPageKey = value;
                this.OnPropertyChanged();
            }
        }

        public object Parameter { get; private set; }

        #endregion

        #region Ctors and Methods

        public FrameNavigationService()
        {
            this.pagesByKey = new Dictionary<string, Uri>();
            this.historic = new List<string>();
        }

        public void GoBack()
        {
            if (this.historic.Count > 1)
            {
                this.historic.RemoveAt(this.historic.Count - 1);
                this.NavigateTo(this.historic.Last(), null);
            }
        }

        public void NavigateTo(string pageKey)
        {
            this.NavigateTo(pageKey, null);
        }

        public virtual void NavigateTo(string pageKey, object parameter)
        {
            lock (this.pagesByKey)
            {
                if (!this.pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException($"No such page: {pageKey} ", nameof(pageKey));
                }

                if (GetDescendantFromName(Application.Current.MainWindow, "MainFrame") is Frame frame)
                {
                    frame.Source = this.pagesByKey[pageKey];
                }

                this.Parameter = parameter;
                this.historic.Add(pageKey);
                this.CurrentPageKey = pageKey;
            }
        }

        public void Configure(string key, Uri pageType)
        {
            lock (this.pagesByKey)
            {
                if (this.pagesByKey.ContainsKey(key))
                {
                    this.pagesByKey[key] = pageType;
                }
                else
                {
                    this.pagesByKey.Add(key, pageType);
                }
            }
        }

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                if (VisualTreeHelper.GetChild(parent, i) is FrameworkElement frameworkElement)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }

            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}