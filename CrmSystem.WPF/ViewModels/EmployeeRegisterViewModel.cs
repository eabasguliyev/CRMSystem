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


            if (IsRequestedAccount(NewEmployee.Email, out RequestedEmployee requestedEmployee))
            {
                MoveDetails(requestedEmployee, NewEmployee);
                _unitOfWork.RequestedEmployees.Remove(requestedEmployee);
            }
            
            RegisterAccount(NewEmployee);

            _unitOfWork.Save();

            MessageBox.Show("Account created. You can login now.", "Info", MessageBoxButton.OK,
                MessageBoxImage.Information);

            LoadLoginView?.Invoke();
        }

        private void MoveDetails(RequestedEmployee requestedEmployee, Employee employee)
        {
            employee.Email = requestedEmployee.Email;
            employee.Role = requestedEmployee.Role;
            employee.Profile = requestedEmployee.Profile;
            employee.Company = requestedEmployee.Company;
        }

        private bool IsRequestedAccount(string email, out RequestedEmployee requestedEmployee)
        {
            requestedEmployee = _unitOfWork.RequestedEmployees.SingleOrDefault(re => re.Email == email);
            return requestedEmployee != null;
        }

        private void RegisterAccount(Employee employee)
        {
            _unitOfWork.Employees.Add(employee);
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