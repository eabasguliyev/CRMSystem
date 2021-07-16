using System;
using System.Windows;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;
using CrmSystem.WPF.Models.Services;

namespace CrmSystem.WPF.ViewModels
{
    public class EmployeeRegisterViewModel:ObservableObject
    {
        private readonly IUnitOfWork _unitOfWork;
        public ICommand SignUpClickCommand { get; set; }

        public Employee NewEmployee { get; set; }
        public EmployeeRegisterViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            NewEmployee = new Employee();
            SignUpClickCommand = new RelayCommand(SignUpClick);
        }

        private void SignUpClick()
        {
            // TODO signup.

            PrepareAccount();

            _unitOfWork.Employees.Add(NewEmployee);
            _unitOfWork.Save();

            MessageBox.Show("Account created. You can login now.", "Info", MessageBoxButton.OK,
                MessageBoxImage.Information);

            LoadLoginView?.Invoke();
        }

        public event Action LoadLoginView;

        private void PrepareAccount()
        {                     
            NewEmployee.Password = new Sha256Hash().CreateHash(NewEmployee.Password);

            NewEmployee.Role = RoleOption.Ceo;
            NewEmployee.Profile = ProfileOption.SuperAdmin;
        }
    }
}