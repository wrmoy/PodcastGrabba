using PodcastGrabba.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PodcastGrabba.Views
{
    public sealed partial class SearchView : PivotItem
    {
        public SearchView()
        {
            this.DataContext = new SearchViewModel();
            this.InitializeComponent();
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
