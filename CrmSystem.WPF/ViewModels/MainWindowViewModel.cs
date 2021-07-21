using System.ComponentModel;
using System.Windows;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.EntityFramework;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class MainWindowViewModel:ObservableObject
    {
        private EmployeeLoginViewModel _employeeLoginViewModel;
        private EmployeeRegisterViewModel _employeeRegisterViewModel;
        private MainViewModel _mainViewModel;

        private IUnitOfWork _unitOfWork;

        private ObservableObject _currentViewModel;

        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set => base.SetProperty(ref _currentViewModel, value);
        }

        public MainWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            _unitOfWork = new UnitOfWork(new CrmSystemContextFactory().Create());

            _employeeLoginViewModel = new EmployeeLoginViewModel(_unitOfWork);
            _employeeLoginViewModel.LoggedIn += OnLoggedIn;
            _employeeLoginViewModel.RegisterButtonClick += NavToRegisterView;

            _employeeRegisterViewModel = new EmployeeRegisterViewModel(_unitOfWork);
            _employeeRegisterViewModel.LoadLoginView += NavToLoginView;

            _mainViewModel = new MainViewModel(_unitOfWork);
            _mainViewModel.LogoutEvent += NavToLoginView;

            CurrentViewModel = _employeeLoginViewModel;
        }

        private void NavToLoginView()
        {
            CurrentViewModel = _employeeLoginViewModel;
        }

        private void NavToRegisterView()
        {
            CurrentViewModel = _employeeRegisterViewModel;
        }

        private void OnLoggedIn(Employee employee)
        {
            App.LoggedUser = employee;

            if (employee.Company != null)
                App.Company = employee.Company;

            CurrentViewModel = _mainViewModel;
        }

        public void OnClosing()
        {
            _unitOfWork.Dispose();
        }
    }
}