using System;
using System.Windows;
using System.Windows.Input;
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

        public EmployeeLoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            var repo = new EmployeeRepository(new CrmSystemContextFactory().Create());

            var state = new EmployeeLogin(repo).Login(Email, Password, out Employee employee);

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