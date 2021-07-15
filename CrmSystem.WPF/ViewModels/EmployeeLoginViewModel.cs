using System;
using System.Windows;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.EntityFramework;
using CrmSystem.EntityFramework.Repositories;
using CrmSystem.WPF.Helpers;
using CrmSystem.WPF.ViewModels.Services;

namespace CrmSystem.WPF.ViewModels
{
    public class EmployeeLoginViewModel:ObservableObject
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public ICommand LoginCommand { get; set; }

        public event Action<Employee> LoggedIn;

        private IUnitOfWork _unitOfWork;

        public EmployeeLoginViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            var state = new EmployeeLogin(_unitOfWork.Employees).Login(Email, Password, out Employee employee);

            if (state == LoginStateOption.WrongEmail)
            {
                MessageBox.Show("Email is wrong", "Wrong credential", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            if (state == LoginStateOption.WrongPassword)
            {
                MessageBox.Show("Password is wrong", "Wrong credential", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"Welcome {employee.FirstName + employee.LastName}", "Info", MessageBoxButton.OK,
                MessageBoxImage.Information);

            LoggedIn?.Invoke(employee);
        }
    }
}