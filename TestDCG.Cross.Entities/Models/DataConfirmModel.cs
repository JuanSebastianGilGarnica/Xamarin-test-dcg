namespace TestDCG.Cross.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Prism.Mvvm;

    public class DataConfirmModel : BindableBase
    {
        private IList<Municipalitie> _allMunicipalities;

        string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnModelChange.Invoke(this);
                RaisePropertyChanged();
            }
        }

        IList<Department> _departments;
        public IList<Department> Departments
        {
            get => _departments;
            set
            {
                _departments = value;
                RaisePropertyChanged();
            }
        }

        Department _departamentSelected;
        public Department DepartamentSelected
        {
            get => _departamentSelected;
            set
            {
                _departamentSelected = value;
                if(_departamentSelected != null)
                {
                    LoadMunicipalitie(_departamentSelected);
                    OnModelChange.Invoke(this);
                }
                RaisePropertyChanged();
            }
        }


        IList<Municipalitie> _municipalities;
        public IList<Municipalitie> Municipalities
        {
            get=> _municipalities;
            set
            {
                _municipalities = value;
                RaisePropertyChanged();
            }
        }

        Municipalitie _municipalitieSelected;
        public Municipalitie MunicipalitieSelected
        {
            get => _municipalitieSelected;
            set
            {
                _municipalitieSelected = value;
                OnModelChange.Invoke(this);
                RaisePropertyChanged();
            }
        }

        public Action<DataConfirmModel> OnModelChange { get; set; }

        public DataConfirmModel(IList<Municipalitie> municipalities, IList<Department> department)
        {
            OnModelChange = new Action<DataConfirmModel>((e) => { });
            Departments = department;
            _allMunicipalities = municipalities;
        }

        private void LoadMunicipalitie(Department departamentSelected)
        {
            MunicipalitieSelected = null;
            Municipalities = _allMunicipalities.Where(m => m.DepartamentId == departamentSelected.Id).ToList();
        }
    }
}
