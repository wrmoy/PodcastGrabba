using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;
using PodcastGrabba.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace PodcastGrabba.Views
{
    public sealed partial class SearchView : PivotItem, IView
    {
        public SearchView()
        {
            this.InitializeComponent();
        }

        [Dependency]
        public SearchViewModel ViewModel
        {
            set
            {
                DataContext = value;
            }
        }

        public void SearchBox_GotFocus(object sender, RoutedEventArgs args)
        {
            var searchBox = (TextBox)sender;
            searchBox.GotFocus -= this.SearchBox_GotFocus;
            searchBox.Text = string.Empty;
        }

        private void SearchBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key != Windows.System.VirtualKey.Enter)
            {
                return;
            }

            var viewModel = this.DataContext as SearchViewModel;
            if (viewModel == null)
            {
                return;
            }

            viewModel.SearchCommand.Execute(null);
        }
    }
}
