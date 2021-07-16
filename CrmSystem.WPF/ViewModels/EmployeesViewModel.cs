using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using CrmSystem.Domain;
using CrmSystem.Domain.Models;
using CrmSystem.WPF.Helpers;

namespace CrmSystem.WPF.ViewModels
{
    public class EmployeesViewModel:ObservableObject
    {
        private IUnitOfWork _unitOfWork;
        private ObservableCollection<BaseEmployee> _employees;

        private AddEmployeeViewModel _addUserViewModel;
        private EmployeeInfoViewModel _employeeInfoViewModel;

        private ObservableObject _currentViewModel;

        private BaseEmployee _selectedEmployee;

        public ObservableCollection<BaseEmployee> Employees
        {
            get => _employees;
            set => base.SetProperty(ref _employees, value);
        }

        public BaseEmployee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                base.SetProperty(ref _selectedEmployee, value);

                _employeeInfoViewModel.SelectedEmployee = _selectedEmployee;
                base.SetProperty(ref _currentViewModel, _employeeInfoViewModel, nameof(CurrentViewModel));
            }
        }

        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set => base.SetProperty(ref _currentViewModel, value);
        }


        public ICommand AddUserClickCommand { get; set; }

        public EmployeesViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _addUserViewModel = new AddEmployeeViewModel(unitOfWork);
            _addUserViewModel.AddUserOrCancelOperation += NavToEmployeesView;

            _employeeInfoViewModel = new EmployeeInfoViewModel();

            AddUserClickCommand = new RelayCommand(AddUserClick);
        }

        private void NavToEmployeesView(object sender, AddEmployeeEventArgs e)
        {
            CurrentViewModel = null;

            if(e.Added)
                LoadEmployees();
        }

        private void AddUserClick()
        {
            CurrentViewModel = _addUserViewModel;
        }


        public void LoadEmployees()
        {
            var employees = new List<BaseEmployee>();

            employees.AddRange(_unitOfWork.Employees.Find(e => e.Company.Id == App.Company.Id));
            employees.AddRange(_unitOfWork.RequestedEmployees.Find(e => e.Company.Id == App.Company.Id));

            Employees = new ObservableCollection<BaseEmployee>(employees);
        }
    }
}