namespace TestDCG.App.References
{
    using Prism.AppModel;
    using Prism.Mvvm;
    using Prism.Navigation;

    public class ViewModelBase : BindableBase, INavigationAware, IDestructible, IApplicationLifecycleAware
    {
        protected readonly INavigationService NavigationService;

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Destroy()
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        public virtual void OnResume()
        {
        }

        public virtual void OnSleep()
        {
        }
    }
}
