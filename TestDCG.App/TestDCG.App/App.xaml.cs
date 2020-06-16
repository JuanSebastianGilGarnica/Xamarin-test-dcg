using Prism;
using Prism.Autofac;
using Prism.Ioc;
using TestDCG.App.ViewModels;
using TestDCG.App.Views;
using TestDCG.Cross.Business;
using TestDCG.Cross.Interface;
using TestDCG.DataAccess.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TestDCG.App
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("App:///NavigationPage/LoginView").ConfigureAwait(false);
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterServices(containerRegistry);
            RegisterViewModels(containerRegistry);
            RegisterBusiness(containerRegistry);
        }

        private void RegisterBusiness(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDataConfirmBll, DataConfirmBll>();
        }

        private void RegisterViewModels(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(); 
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>(); 
            containerRegistry.RegisterForNavigation<DataConfirmView, DataConfirmViewModel>();
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();
        }

        private void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IServiceDataClient, ServiceDataClient>();
        }
    }
}
