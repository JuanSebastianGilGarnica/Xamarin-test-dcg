namespace TestDCG.App.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Prism.Navigation;
    using TestDCG.App.References;
    using TestDCG.App.Resources;
    using TestDCG.Cross.Entities.Models;
    using TestDCG.Cross.Interface;
    using Xamarin.Forms;

    public class DataConfirmViewModel : ViewModelBase
    {
        DataConfirmModel _model;

        public DataConfirmModel Model
        {
            get => _model;
            set
            {
                _model = value;
                RaisePropertyChanged();
            }
        }

        string _userInfoText;
        public string UserInfoText
        {
            get => _userInfoText;
            set
            {
                _userInfoText = value;
                RaisePropertyChanged();
            }
        }

        bool _canConfirm;
        public bool CanConfirm
        {
            get => _canConfirm;
            set
            {
                _canConfirm = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ConfirmCommand { get; set; }

        readonly IDataConfirmBll _bll;

        string _userName;

        public DataConfirmViewModel(INavigationService navigationService, IDataConfirmBll bll) : base(navigationService)
        {
            _bll = bll;
            InitView().ConfigureAwait(false);
            ConfirmCommand = new Command(() => Confirm());
        }

        private async Task InitView()
        {
            Model = await _bll.LoadModel().ConfigureAwait(false);
            Model.OnModelChange += (e) => ValidateDataConfirmation(e);
        }

        private void Confirm()
        {
            var prms = new NavigationParameters { { "userInfo", new UserDataModel
            {
                Address = Model.Address,
                Department =  Model.DepartamentSelected,
                Municipalitie =  Model.MunicipalitieSelected,
                UserName = _userName
            } } };
            NavigationService.NavigateAsync("App:///NavigationPage/HomeView", prms).ConfigureAwait(false);
        }

        private void ValidateDataConfirmation(DataConfirmModel model)
        {
            CanConfirm = !string.IsNullOrEmpty(model.Address) && model.DepartamentSelected != null && model.MunicipalitieSelected != null;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            string keyUserName = "username";
            if (parameters.ContainsKey(keyUserName))
            {
                _userName = parameters.GetValue<string>(keyUserName);
                UserInfoText = string.Format(TxtResource.LabeTxtInfo, _userName);
            }
        }
    }
}
