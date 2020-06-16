namespace TestDCG.App.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Prism.Navigation;
    using TestDCG.App.References;
    using TestDCG.App.Views;
    using Xamarin.Forms;

    public class LoginViewModel : ViewModelBase
    {
        string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                ValidateCanLogin();
                RaisePropertyChanged();
            }
        }

        string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                ValidateCanLogin();
                RaisePropertyChanged();
            }
        }

        bool _canLogin;
        public bool CanLogin
        {
            get => _canLogin;
            set
            {
                _canLogin = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            LoginCommand = new Command(() => Login(), () => CanLogin);
        }

        private void Login()
        {
            NavigationParameters parms = new NavigationParameters
            {
                { "username", UserName }
            };
            NavigationService.NavigateAsync(nameof(DataConfirmView), parms).ConfigureAwait(false);
        }

        private void ValidateCanLogin()
        {
            CanLogin = !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
        }
        
    }
}
