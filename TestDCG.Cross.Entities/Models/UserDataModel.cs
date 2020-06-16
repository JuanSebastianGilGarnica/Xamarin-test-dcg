namespace TestDCG.Cross.Entities.Models
{
    using Prism.Mvvm;

    public class UserDataModel : BindableBase
    {
        Department _department;
        public Department Department
        {
            get => _department;
            set
            {
                _department = value;
                RaisePropertyChanged();
            }
        }

        Municipalitie _municipalitie;
        public Municipalitie Municipalitie
        {
            get => _municipalitie;
            set
            {
                _municipalitie = value;
                RaisePropertyChanged();
            }
        }

        string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                RaisePropertyChanged();
            }
        }

        string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                RaisePropertyChanged();
            }
        }
    }
}
