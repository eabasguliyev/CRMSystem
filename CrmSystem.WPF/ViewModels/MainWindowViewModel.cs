using System.ComponentModel;
using System.Windows;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class MainWindowViewModel:ObservableObject
    {
        private EmployeeLoginViewModel _employeeLoginViewModel;
        private MainViewModel _mainViewModel;



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
            _employeeLoginViewModel = new EmployeeLoginViewModel();
            _employeeLoginViewModel.LoggedIn += OnLoggedIn;

            _mainViewModel = new MainViewModel();

            CurrentViewModel = _employeeLoginViewModel;
        }

        private void OnLoggedIn(Employee employee)
        {
            _mainViewModel.Employee = employee;

            CurrentViewModel = _mainViewModel;
        }
    }
}