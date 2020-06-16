namespace TestDCG.App.ViewModels
{
    using System.Windows.Input;
    using Prism.Navigation;
    using TestDCG.App.References;
    using TestDCG.Cross.Entities.Models;
    using Xamarin.Forms;

    public class HomeViewModel : ViewModelBase
    {
        UserDataModel _model;
        public UserDataModel Model
        {
            get => _model;
            set
            {
                _model = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LogOutCommand { get; set; }

        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            LogOutCommand = new Command(() => LogOut(), () => true);
        }

        private void LogOut()
        {
            NavigationService.NavigateAsync("App:///NavigationPage/LoginView").ConfigureAwait(false);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            string keyUserInfo = "userInfo";
            if (parameters.ContainsKey(keyUserInfo))
            {
                Model = parameters.GetValue<UserDataModel>(keyUserInfo);
            }
        }
    }
}
