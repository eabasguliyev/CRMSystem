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

            _mainViewModel = new MainViewModel(_unitOfWork);

            CurrentViewModel = _employeeLoginViewModel;
        }

        private void OnLoggedIn(Employee employee)
        {
            _mainViewModel.Employee = employee;

            CurrentViewModel = _mainViewModel;
        }
    }
}