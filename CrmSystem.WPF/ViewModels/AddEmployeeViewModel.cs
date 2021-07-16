using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class AddEmployeeEventArgs : EventArgs
    {
        public bool Added { get; set; }
    }
    public class AddEmployeeViewModel:ObservableObject
    {
        private readonly IUnitOfWork _unitOfWork;
        private List<RoleOption> _roles;
        private List<ProfileOption> _profiles;


        public RequestedEmployee NewEmployee { get; set; }
        public AddEmployeeViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            NewEmployee = new RequestedEmployee();

            SaveButtonClickCommand = new RelayCommand(SaveButton);
            CancelButtonClickCommand= new RelayCommand(CancelButton);
        }

        private void CancelButton()
        {
            AddUserOrCancelOperation?.Invoke(this, new AddEmployeeEventArgs()
            {
                Added = false
            });
        }

        public event EventHandler<AddEmployeeEventArgs> AddUserOrCancelOperation;

        public List<RoleOption> Roles
        {
            get => _roles;
            set => base.SetProperty(ref _roles, value);
        }

        public List<ProfileOption> Profiles
        {
            get => _profiles;
            set => base.SetProperty(ref _profiles, value);
        }

        private void SaveButton()
        {
            NewEmployee.Company = App.Company;
            _unitOfWork.RequestedEmployees.Add(NewEmployee);
            _unitOfWork.Save();

            AddUserOrCancelOperation?.Invoke(this, new AddEmployeeEventArgs()
            {
                Added = true
            });
        }

        public ICommand SaveButtonClickCommand { get; set; }
        public ICommand CancelButtonClickCommand { get; set; }


        public void LoadProfiles()
        {
            Profiles = Enum.GetValues(typeof(ProfileOption)).Cast<ProfileOption>()
                .Where(p => p != ProfileOption.SuperAdmin).ToList();
        }

        public void LoadRoles()
        {
            Roles = Enum.GetValues(typeof(RoleOption)).Cast<RoleOption>()
                .Where(r => r != RoleOption.Ceo)
                .ToList();
        }
    }
}