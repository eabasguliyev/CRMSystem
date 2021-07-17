using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;
using CrmSystem.WPF.Models;

namespace CrmSystem.WPF.ViewModels
{
    public class EditEmployeeViewModel:ObservableObject
    {
        private readonly IUnitOfWork _unitOfWork;
        private BaseEmployee _employee;

        private List<RoleOption> _roles;
        private List<ProfileOption> _profiles;
        private BaseEmployee _editableEmployee;

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
        public EditEmployeeViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            CancelButtonClickCommand = new RelayCommand(CancelButton);
            SaveButtonClickCommand = new RelayCommand(SaveButton);
        }
        private void CancelButton()
        {
            AddUserOrCancelOperation?.Invoke(this, new AddEditEmployeeEventArgs()
            {
                IsChanged = false
            });
        }
        public event EventHandler<AddEditEmployeeEventArgs> AddUserOrCancelOperation;
        private void SaveButton()
        {
            Employee.Update(EditableEmployee);
            _unitOfWork.Save();

            AddUserOrCancelOperation?.Invoke(this, new AddEditEmployeeEventArgs()
            {
                IsChanged = true
            });
        }

        public BaseEmployee Employee
        {
            get => _employee;
            set
            {
                _employee = value;

                this.CopyEmployee(_employee);
            }
        }

        public BaseEmployee EditableEmployee
        {
            get => _editableEmployee;
            set => base.SetProperty(ref _editableEmployee, value);
        }

        public ICommand CancelButtonClickCommand { get; set; }
        public ICommand SaveButtonClickCommand { get; set; }

        private void CopyEmployee(BaseEmployee employee)
        {
            EditableEmployee = employee.Clone() as BaseEmployee;
        }
        
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