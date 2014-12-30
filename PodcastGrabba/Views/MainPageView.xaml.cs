using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Unity;
using PodcastGrabba.ViewModels;
using Windows.UI.Xaml.Navigation;

namespace PodcastGrabba.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPageView : VisualStateAwarePage, IView
    {
        public MainPageView()
        {
            this.InitializeComponent();
        }

        [Dependency]
        public MainPageViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
