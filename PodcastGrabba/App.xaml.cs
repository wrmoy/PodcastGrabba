using DownloaderService;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Microsoft.Practices.Unity;
using PodcastGrabba.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace PodcastGrabba
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : MvvmAppBase
    {
        private TransitionCollection transitions;
        private readonly UnityContainer diContainer = new UnityContainer();

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        protected override Type GetPageType(string pageToken)
        {
            var assemblyQualifiedAppType = this.GetType().AssemblyQualifiedName;
            var pageNameWithParameter = assemblyQualifiedAppType.Replace(this.GetType().FullName, this.GetType().Namespace + ".Views.{0}View");
            var viewFullName = string.Format(CultureInfo.InvariantCulture, pageNameWithParameter, pageToken);
            var viewType = Type.GetType(viewFullName);
            return viewType;
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            var task = base.OnInitializeAsync(args);

            // Register MvvmAppBase services with the container so that view models can take dependencies on them
            this.diContainer.RegisterInstance<ISessionStateService>(SessionStateService);
            this.diContainer.RegisterInstance<INavigationService>(NavigationService);

            // App specific registrations
            this.diContainer.RegisterType<IHttpClientWrapper, HttpClientWrapper>();
            this.diContainer.RegisterType<IPodcastSearcher, iTunesSearcher>();

            ViewModelLocationProvider.SetDefaultViewModelFactory(viewModelType => this.diContainer.Resolve(viewModelType));
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(this.GetViewModelTypeFromView);

            return task;
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            // Use the logical name for the view to navigate to. The default convention
            // in the NavigationService will be to append "Page" to the name and look 
            // for that page in a .Views child namespace in the project. IF you want another convention
            // for mapping view names to view types, you can override 
            // the MvvmAppBase.GetPageNameToTypeResolver method
            NavigationService.Navigate("MainPage", null);
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Restores the content transitions after the app has launched.
        /// </summary>
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }

        /// <summary>
        /// Invoked when application execution is being suspended. Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private Type GetViewModelTypeFromView(Type viewModelType)
        {
            var assemblyQualifiedAppType = this.GetType().AssemblyQualifiedName;
            var pageNameWithParameter = assemblyQualifiedAppType.Replace(this.GetType().FullName, this.GetType().Namespace + ".ViewModels.{0}Model");
            var viewFullName = string.Format(CultureInfo.InvariantCulture, pageNameWithParameter, viewModelType.Name);
            var viewType = Type.GetType(viewFullName);
            return viewType;
        }
    }
}
