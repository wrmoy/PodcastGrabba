using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;
using PodcastGrabba.ViewModels;
using Windows.UI.Xaml.Controls;

namespace PodcastGrabba.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserPodcastsView : PivotItem, IView
    {
        public UserPodcastsView()
        {
            this.InitializeComponent();
        }

        [Dependency]
        public UserPodcastsViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }
    }
}
